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
using Volo.Abp.Identity;

namespace KST.ABP.Organizations
{
    public class OrganizationUnitAppService : OrganizationsAppService, IOrganizationUnitAppService
    {
        private readonly OrganizationUnitManager _organizationUnitManager;
        private readonly IRepository<OrganizationUnit, Guid> _organizationUnitRepository;
        private readonly IRepository<UserOrganizationUnit, Guid> _userOrganizationUnitRepository;
        private IAsyncQueryableExecuter AsyncQueryableExecuter { get; set; }
        private IdentityUserManager UserManager { get; set; }

        public OrganizationUnitAppService(
            OrganizationUnitManager organizationUnitManager,
            IRepository<OrganizationUnit, Guid> organizationUnitRepository,
            IRepository<UserOrganizationUnit, Guid> userOrganizationUnitRepository,
            IdentityUserManager userManager)
        {
            _organizationUnitManager = organizationUnitManager;
            _organizationUnitRepository = organizationUnitRepository;
            _userOrganizationUnitRepository = userOrganizationUnitRepository;
            UserManager = userManager;
            AsyncQueryableExecuter = DefaultAsyncQueryableExecuter.Instance;
        }

        public async Task<ListResultDto<OrganizationUnitDto>> GetOrganizationUnits()
        {
            var query =
                from ou in _organizationUnitRepository.AsQueryable()
                join uou in _userOrganizationUnitRepository.AsQueryable() on ou.Id equals uou.OrganizationUnitId into g
                select new { ou, memberCount = g.Count() };

            var items = await AsyncQueryableExecuter.ToListAsync(query);

            return new ListResultDto<OrganizationUnitDto>(
                items.Select(item =>
                {

                    var dto = ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(item.ou);
                    dto.MemberCount = item.memberCount;
                    return dto;
                }).ToList());
        }

        public async Task<PagedResultDto<OrganizationUnitUserListDto>> GetOrganizationUnitUsers(GetOrganizationUnitUsersInput input)
        {
            var query = from uou in _userOrganizationUnitRepository.AsQueryable()
                        join ou in _organizationUnitRepository.AsQueryable() on uou.OrganizationUnitId equals ou.Id
                        join user in UserManager.Users on uou.UserId equals user.Id
                        where uou.OrganizationUnitId == input.Id
                        select new { uou, user };

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);
            var items = await AsyncQueryableExecuter.ToListAsync(query.PageBy(input));

            return new PagedResultDto<OrganizationUnitUserListDto>(
                totalCount,
                items.Select(item =>
                {

                    var dto = new OrganizationUnitUserListDto
                    {
                        Name = item.user.Name,
                        Surname = item.user.Surname,
                        UserName = item.user.UserName,
                        EmailAddress = item.user.Email,
                        AddedTime = item.user.CreationTime
                    };

                    return dto;
                }).ToList());
        }

        //[Authorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree)]
        public async Task<OrganizationUnitDto> CreateOrganizationUnit(CreateOrganizationUnitInput input)
        {
            var organizationUnit = new OrganizationUnit(CurrentTenant.Id, input.DisplayName, input.ParentId);

            await _organizationUnitManager.CreateAsync(organizationUnit);
            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(organizationUnit);
        }

        //[Authorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree)]
        public async Task<OrganizationUnitDto> UpdateOrganizationUnit(UpdateOrganizationUnitInput input)
        {
            var organizationUnit = await _organizationUnitRepository.GetAsync(input.Id);

            organizationUnit.DisplayName = input.DisplayName;

            await _organizationUnitManager.UpdateAsync(organizationUnit);

            return await CreateOrganizationUnitDto(organizationUnit);
        }

        ////[Authorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree)]
        public async Task<OrganizationUnitDto> MoveOrganizationUnit(MoveOrganizationUnitInput input)
        {
            await _organizationUnitManager.MoveAsync(input.Id, input.NewParentId);

            return await CreateOrganizationUnitDto(
                await _organizationUnitRepository.GetAsync(input.Id)
                );
        }

        //[Authorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree)]
        public async Task DeleteOrganizationUnit(EntityDto<Guid> input)
        {
            await _organizationUnitManager.DeleteAsync(input.Id);
        }


        //[Authorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers)]
        public async Task RemoveUserFromOrganizationUnit(UserToOrganizationUnitInput input)
        {
            await _userOrganizationUnitRepository.DeleteAsync(m => m.UserId == input.UserId && m.OrganizationUnitId == input.OrganizationUnitId);
        }

        //[Authorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers)]
        public async Task AddUsersToOrganizationUnit(UsersToOrganizationUnitInput input)
        {
            foreach (var userId in input.UserIds)
            {
                await _userOrganizationUnitRepository.InsertAsync(new UserOrganizationUnit(CurrentTenant.Id, userId, input.OrganizationUnitId));
            }
        }

        //[Authorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers)]
        public async Task<PagedResultDto<NameValue>> FindUsers(FindOrganizationUnitUsersInput input)
        {
            var userIdsInOrganizationUnit = _userOrganizationUnitRepository.AsQueryable()
                .Where(uou => uou.OrganizationUnitId == input.OrganizationUnitId)
                .Select(uou => uou.UserId);

            var query = UserManager.Users
                .Where(u => !userIdsInOrganizationUnit.Contains(u.Id))
                .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    u =>
                        u.Name.Contains(input.Filter) ||
                        u.Surname.Contains(input.Filter) ||
                        u.UserName.Contains(input.Filter) ||
                        u.Email.Contains(input.Filter)
                );

            var userCount = await AsyncQueryableExecuter.CountAsync(query);
            var users = await AsyncQueryableExecuter
                .ToListAsync(query
                .OrderBy(u => u.Name)
                .ThenBy(u => u.Surname)
                .PageBy(input));

            return new PagedResultDto<NameValue>(
                userCount,
                users.Select(u =>
                    new NameValue(
                        u.NormalizedUserName + " (" + u.Email + ")",
                        u.Id.ToString()
                    )
                ).ToList()
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
