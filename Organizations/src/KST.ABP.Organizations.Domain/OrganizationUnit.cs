using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace KST.ABP.Organizations
{


    public class OrganizationUnit : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {

        public virtual Guid? TenantId { get; set; }



        /// <summary>
        /// Parent <see cref="OrganizationUnit"/> Id.
        /// Null, if this OU is root.
        /// </summary>
        public virtual Guid? ParentId { get; set; }

        public virtual OrganizationUnit Parent { get; set; }

        /// <summary>
        /// 该组织单元的层次代码
        /// Example: "00001.00042.00005".
        /// This is a unique code for a Tenant.
        /// It's changeable if OU hierarch is changed.
        /// </summary>
        [Required]
        [StringLength(OrganizationUnitOptions.MaxCodeLength)]
        public virtual string Code { get; set; }

        /// <summary>
        /// Display name of this role.
        /// </summary>
        [Required]
        [StringLength(OrganizationUnitOptions.MaxDisplayNameLength)]
        public virtual string DisplayName { get; set; }

        public virtual ICollection<OrganizationUnit> Children { get; set; }

        public OrganizationUnit(Guid? tenantId, string displayName, Guid? parentId = null)
        {
            TenantId = tenantId;
            DisplayName = displayName;
            ParentId = parentId;
        }

        public OrganizationUnit(Guid id, Guid? tenantId, string displayName, Guid? parentId)
            : base(id)

        {
            TenantId = tenantId;
            DisplayName = displayName;
            ParentId = parentId;
        }

        public OrganizationUnit(Guid id) : base(id)
        {

        }

        /// <summary>
        /// Example: if numbers are 4,2 then returns "00004.00002";
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string CreateCode(params int[] numbers)
        {
            if (numbers.IsNullOrEmpty())
            {
                return null;
            }

            return numbers.Select(number => number.ToString(new string('0', OrganizationUnitOptions.CodeUnitLength))).JoinAsString(".");
        }

        /// <summary>
        /// Example: if parentCode = "00001", childCode = "00042" then returns "00001.00042".
        /// </summary>
        /// <param name="parentCode">Parent code. Can be null or empty if parent is a root.</param>
        /// <param name="childCode">Child code.</param>
        /// <returns></returns>
        public static string AppendCode(string parentCode, string childCode)
        {
            if (childCode.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(childCode), "childCode can not be null or empty.");
            }

            if (parentCode.IsNullOrEmpty())
            {
                return childCode;
            }

            return parentCode + "." + childCode;
        }

        /// <summary>
        /// Example: if code = "00019.00055.00001" and parentCode = "00019" then returns "00055.00001".
        /// </summary>
        /// <param name="code"></param>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        public static string GetRelativeCode(string code, string parentCode)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            if (parentCode.IsNullOrEmpty())
            {
                return code;
            }

            if (code.Length == parentCode.Length)
            {
                return null;
            }

            return code.Substring(parentCode.Length + 1);
        }

        /// <summary>
        /// Example: if code = "00019.00055.00001" returns "00019.00055.00002".
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string CalculateNextCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var parentCode = GetParentCode(code);
            var lastUnitCode = GetLastUnitCode(code);

            return AppendCode(parentCode, CreateCode(Convert.ToInt32(lastUnitCode) + 1));
        }

        /// <summary>
        /// Example: if code = "00019.00055.00001" returns "00001".
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetLastUnitCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var splittedCode = code.Split('.');
            return splittedCode[splittedCode.Length - 1];
        }

        /// <summary>
        /// Example: if code = "00011.00053.00001" returns "00011.00053".
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetParentCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var splittedCode = code.Split('.');
            if (splittedCode.Length == 1)
            {
                return null;
            }

            return splittedCode.Take(splittedCode.Length - 1).JoinAsString(".");
        }
    }
}
