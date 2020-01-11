using System;
using System.Collections.Generic;
using System.Text;

namespace KST.ABP.Organizations.Dto
{
    public class UsersToOrganizationUnitInput
    {
        public Guid[] UserIds { get; set; }

        
        public Guid OrganizationUnitId { get; set; }
    }
}
