using System;
using System.Collections.Generic;
using System.Text;

namespace KST.ABP.Organizations.Dto
{
    public class FindOrganizationUnitUsersInput : PagedAndFilteredResultRequest
    {
        public Guid OrganizationUnitId { get; set; }
    }
}
