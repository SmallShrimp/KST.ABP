﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace KST.ABP.Organizations
{
    public class UserOrganizationUnit : CreationAuditedEntity<Guid>, IMultiTenant, ISoftDelete
    {
        
        public virtual Guid? TenantId { get; set; }

        public virtual Guid OrganizationUnitId { get; set; }

        public virtual Guid UserId { get; set; }

        public virtual bool IsDeleted { get; set; }

        public UserOrganizationUnit()
        {

        }

        public UserOrganizationUnit(Guid? tenantId, Guid userId, Guid organizationUnitId)
        {
            TenantId = tenantId;
            UserId = userId;
            OrganizationUnitId = organizationUnitId;
        }

    }
}
