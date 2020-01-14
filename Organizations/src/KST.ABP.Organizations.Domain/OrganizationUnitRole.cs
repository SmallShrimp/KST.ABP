using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace KST.ABP.Organizations
{
    public class OrganizationUnitRole : CreationAuditedEntity<Guid>, IMultiTenant, ISoftDelete
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid OrganizationUnitId { get; set; }

        public virtual Guid RoleId { get; set; }

        public virtual bool IsDeleted { get; set; }

        public OrganizationUnitRole()
        {

        }

        public OrganizationUnitRole(Guid? tenantId, Guid roleId, Guid organizationUnitId)
        {
            TenantId = tenantId;
            RoleId = roleId;
            OrganizationUnitId = organizationUnitId;
        }
    }
}
