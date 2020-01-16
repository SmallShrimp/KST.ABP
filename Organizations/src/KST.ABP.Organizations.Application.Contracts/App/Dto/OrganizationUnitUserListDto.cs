using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace KST.ABP.Organizations.Dto
{
    public class OrganizationUnitUserListDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime AddTime { get; set; }
    }
}
