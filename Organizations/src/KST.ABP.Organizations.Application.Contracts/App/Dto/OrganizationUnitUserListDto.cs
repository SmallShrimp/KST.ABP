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

        public string EmailAddress { get; set; }

        public DateTime AddedTime { get; set; }
    }
}
