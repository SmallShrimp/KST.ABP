using System;
using System.Collections.Generic;
using System.Text;

namespace KST.ABP.Organizations
{
    public interface IMustHaveOrganizationUnit
    {
        /// <summary>
        /// 当前实体<see cref="OrganizationUnit"/>'s Id 。
        /// </summary>
        long OrganizationUnitId { get; set; }
    }
}
