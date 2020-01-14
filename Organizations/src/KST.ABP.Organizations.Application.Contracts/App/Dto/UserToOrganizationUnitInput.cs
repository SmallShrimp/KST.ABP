using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KST.ABP.Organizations.Dto
{
    public class UserToOrganizationUnitInput
    {

        public Guid UserId { get; set; }


        public Guid OrganizationUnitId { get; set; }
    }
}
