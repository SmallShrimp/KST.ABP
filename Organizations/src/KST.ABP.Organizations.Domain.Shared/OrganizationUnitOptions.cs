using System;
using System.Collections.Generic;
using System.Text;

namespace KST.ABP.Organizations
{
    public class OrganizationUnitOptions
    {
        /// <summary>
        /// 属性<see cref="DisplayName"/>的最大长度
        /// </summary>
        public const int MaxDisplayNameLength = 128;

        /// <summary>
        /// UO层次结构的最大深度。
        /// </summary>
        public const int MaxDepth = 16;

        /// <summary>
        /// Length of a code unit between dots.
        /// </summary>
        public const int CodeUnitLength = 5;

        /// <summary>
        /// Maximum length of the <see cref="Code"/> property.
        /// </summary>
        public const int MaxCodeLength = MaxDepth * (CodeUnitLength + 1) - 1;
    }
}
