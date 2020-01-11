using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KST.ABP.Organizations.Dto
{
    public class UpdateOrganizationUnitInput
    {
       
        public Guid Id { get; set; }

        [Required]
        [StringLength(OrganizationUnitOptions.MaxDisplayNameLength)]
        public string DisplayName { get; set; }
    }
}
