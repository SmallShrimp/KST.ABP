using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KST.ABP.Organizations.Dto
{
    public class MoveOrganizationUnitInput
    {
         
        public Guid Id { get; set; }

        public Guid? NewParentId { get; set; }
    }
}
