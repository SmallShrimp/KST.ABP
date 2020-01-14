using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace KST.ABP.Organizations.Dto
{

    [Serializable]
    public class GetOrganizationUnitUsersInput : PagedResultRequestDto, IPagedAndSortedResultRequest
    {
        public Guid Id { get; set; }
        public virtual string Sorting { get; set; }
    }
}
