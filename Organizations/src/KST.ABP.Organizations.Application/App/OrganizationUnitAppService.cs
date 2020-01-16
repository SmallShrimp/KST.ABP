using KST.ABP.Organizations.Dto;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using System.Linq;
using Volo.Abp.Linq;
using KST.ABP.Organizations.Authorization;
using Volo.Abp.Application.Services;
using Volo.Abp.Uow;
using KST.ABP.Organizations.User;

namespace KST.ABP.Organizations
{

    [Authorize]
    public class OrganizationUnitAppService : OrganizationsAppService, IOrganizationUnitAppService
    {
        private readonly OrganizationUnitManager _organizationUnitManager;
        private readonly IRepository<OrganizationUnit, Guid> _organizationUnitRepository;
        private readonly IRepository<UserOrganizationUnit, Guid> _userOrganizationUnitRepository;
        private readonly IRepository<OrganizationUnitUser, Guid> _organizationUnitUsers;
        private IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }

        public OrganizationUnitAppService(
            OrganizationUnitManager organizationUnitManager,
            IRepository<OrganizationUnit, Guid> organizationUnitRepository,
            IRepository<UserOrganizationUnit, Guid> userOrganizationUnitRepository,
            IRepository<OrganizationUnitUser, Guid> organizationUnitUsers)
        {
            _organizationUnitManager = organizationUnitManager;
            _organizationUnitRepository = organizationUnitRepository;
            _userOrganizationUnitRepository = userOrganizationUnitRepository;
            _organizationUnitUsers = organizationUnitUsers;
            AsyncQueryableExecuter = DefaultAsyncQueryableExecuter.Instance;
        }

        public virtual async Task<ListResultDto<OrganizationUnitDto>> GetOrganizationUnitsAsync()
        {
            var query =
                from ou in _organizationUnitRepository
                join uou in _userOrganizationUnitRepository on ou.Id equals uou.OrganizationUnitId into g
                select new { ou, memberCount = g.Count() };

            var items = await AsyncQueryableExecuter.ToListAsync(_organizationUnitRepository);
            var users = _userOrganizationUnitRepository
                 .Where(m => items.Select(i => i.Id).Contains(m.OrganizationUnitId))
                 .ToList();

            return new ListResultDto<OrganizationUnitDto>(items.Select(m =>
               {
                   var r = ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(m);
                   r.MemberCount = users.Count(u => u.OrganizationUnitId == m.Id);
                   return r;
               }).ToList());
        }


        [Authorize(OrganizationsPermissions.ManageOrganizationTree)]
        public virtual async Task<OrganizationUnitDto> CreateOrganizationUnitAsync(CreateOrganizationUnitInput input)
        {
            var organizationUnit = new OrganizationUnit(GuidGenerator.Create(), CurrentTenant.Id, input.DisplayName, input.ParentId);
            organizationUnit.CreatorId = CurrentUser.Id;
            await _organizationUnitManager.CreateAsync(organizationUnit);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(organizationUnit);
        }

        [Authorize(OrganizationsPermissions.ManageOrganizationTree)]
        public virtual async Task<OrganizationUnitDto> UpdateOrganizationUnitAsync(UpdateOrganizationUnitInput input)
        {
            var organizationUnit = await _organizationUnitRepository.GetAsync(input.Id);

            organizationUnit.DisplayName = input.DisplayName;

            await _organizationUnitManager.UpdateAsync(organizationUnit);

            return await CreateOrganizationUnitDto(organizationUnit);
        }

        [Authorize(OrganizationsPermissions.ManageOrganizationTree)]
        public virtual async Task<OrganizationUnitDto> MoveOrganizationUnitAsync(MoveOrganizationUnitInput input)
        {
            await _organizationUnitManager.MoveAsync(input.Id, input.NewParentId);

            return await CreateOrganizationUnitDto(
                await _organizationUnitRepository.GetAsync(input.Id)
                );
        }

        [Authorize(OrganizationsPermissions.ManageOrganizationTree)]
        public virtual async Task DeleteOrganizationUnitAsync(Guid id)
        {
            await _organizationUnitManager.DeleteAsync(id);
        }

        [UnitOfWork]
        [Authorize(OrganizationsPermissions.ManageMembers)]
        public virtual async Task RemoveUserFromOrganizationUnitAsync(UserToOrganizationUnitInput input)
        {
            await _userOrganizationUnitRepository.DeleteAsync(m => m.UserId == input.UserId && m.OrganizationUnitId == input.OrganizationUnitId);
        }

        [UnitOfWork]
        [Authorize(OrganizationsPermissions.ManageMembers)]
        public async Task AddUsersToOrganizationUnitAsync(UsersToOrganizationUnitInput input)
        {
            foreach (var userId in input.UserIds)
            {
                var entity = new UserOrganizationUnit(GuidGenerator.Create(), CurrentTenant.Id, userId, input.OrganizationUnitId);
                await _userOrganizationUnitRepository.InsertAsync(entity);
            }
        }

        [Authorize(OrganizationsPermissions.ManageMembers)]
        public virtual async Task<PagedResultDto<OrganizationUnitUserListDto>> FindUsersAsync(FindOrganizationUnitUsersInput input)
        {
            var userIdsInOrganizationUnit = _userOrganizationUnitRepository.AsQueryable()
                .Where(uou => uou.OrganizationUnitId == input.OrganizationUnitId)
                .Select(uou => uou.UserId);

            var userCount = await AsyncQueryableExecuter.CountAsync(userIdsInOrganizationUnit);
            var users = await AsyncQueryableExecuter
                .ToListAsync(userIdsInOrganizationUnit.PageBy(input));

            var userList = _organizationUnitUsers.Where(u => users.Contains(u.Id))
                .ToList();
            return new PagedResultDto<OrganizationUnitUserListDto>(
                userCount,
                ObjectMapper.Map<List<OrganizationUnitUser>, List<OrganizationUnitUserListDto>>(userList)
            );
        }

        private async Task<OrganizationUnitDto> CreateOrganizationUnitDto(OrganizationUnit organizationUnit)
        {
            var dto = ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(organizationUnit);
            dto.MemberCount = await AsyncQueryableExecuter.CountAsync(_userOrganizationUnitRepository.Where(uou => uou.OrganizationUnitId == organizationUnit.Id));
            return dto;
        }
    }
}
