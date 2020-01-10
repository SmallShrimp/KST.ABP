using System;
using System.Collections.Generic;
using System.Text;

namespace KST.ABP.Organizations
{

    public interface IMayHaveOrganizationUnit
    {
        long? OrganizationUnitId { get; set; }
    }
}
