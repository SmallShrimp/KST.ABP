using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KST.ABP.Organizations.Dto
{
    public class CreateOrganizationUnitInput
    {
        public Guid? ParentId { get; set; }

        [Required]
        [StringLength(OrganizationUnitOptions.MaxDisplayNameLength)]
        public string DisplayName { get; set; }
    }
}
