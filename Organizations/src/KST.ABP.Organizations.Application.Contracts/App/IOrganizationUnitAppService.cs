using KST.ABP.Organizations.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace KST.ABP.Organizations
{
    public interface IOrganizationUnitAppService : IApplicationService
    {
        Task<ListResultDto<OrganizationUnitDto>> GetOrganizationUnitsAsync();

        Task<OrganizationUnitDto> CreateOrganizationUnitAsync(CreateOrganizationUnitInput input);

        Task<OrganizationUnitDto> UpdateOrganizationUnitAsync(UpdateOrganizationUnitInput input);

        Task<OrganizationUnitDto> MoveOrganizationUnitAsync(MoveOrganizationUnitInput input);

        Task DeleteOrganizationUnitAsync(Guid id);

        Task RemoveUserFromOrganizationUnitAsync(UserToOrganizationUnitInput input);

        Task AddUsersToOrganizationUnitAsync(UsersToOrganizationUnitInput input);

        Task<PagedResultDto<Guid>> FindUsersAsync(FindOrganizationUnitUsersInput input);
    }
}
