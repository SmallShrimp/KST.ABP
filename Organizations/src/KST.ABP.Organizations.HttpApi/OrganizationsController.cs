using KST.ABP.Organizations.Dto;
using KST.ABP.Organizations.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace KST.ABP.Organizations
{

    [RemoteService]
    [Area("kst")]
    public class OrganizationsController : AbpController, IOrganizationUnitAppService
    {

        private readonly IOrganizationUnitAppService _organizationUnitAppService;
        public OrganizationsController(IOrganizationUnitAppService organizationUnitAppService)
        {
            LocalizationResource = typeof(OrganizationsResource);
            _organizationUnitAppService = organizationUnitAppService;
        }

        public async Task AddUsersToOrganizationUnitAsync(UsersToOrganizationUnitInput input)
        {
            await _organizationUnitAppService.AddUsersToOrganizationUnitAsync(input);
        }

        public async Task<OrganizationUnitDto> CreateOrganizationUnitAsync(CreateOrganizationUnitInput input)
        {
            return await _organizationUnitAppService.CreateOrganizationUnitAsync(input);
        }

        public async Task DeleteOrganizationUnitAsync(Guid id)
        {
            await _organizationUnitAppService.DeleteOrganizationUnitAsync(id);
        }

        public async Task<PagedResultDto<Guid>> FindUsersAsync(FindOrganizationUnitUsersInput input)
        {
            return await _organizationUnitAppService.FindUsersAsync(input);
        }

        public async Task<ListResultDto<OrganizationUnitDto>> GetOrganizationUnitsAsync()
        {
            return await _organizationUnitAppService.GetOrganizationUnitsAsync();
        }

        public async Task<OrganizationUnitDto> MoveOrganizationUnitAsync(MoveOrganizationUnitInput input)
        {
            return await _organizationUnitAppService.MoveOrganizationUnitAsync(input);
        }

        public async Task RemoveUserFromOrganizationUnitAsync(UserToOrganizationUnitInput input)
        {
            await _organizationUnitAppService.RemoveUserFromOrganizationUnitAsync(input);
        }

        public async Task<OrganizationUnitDto> UpdateOrganizationUnitAsync(UpdateOrganizationUnitInput input)
        {
            return await _organizationUnitAppService.UpdateOrganizationUnitAsync(input);
        }
    }
}
