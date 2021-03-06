﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace KST.ABP.Organizations
{
    public class OrganizationUnitTestDataBuilder : ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IRepository<OrganizationUnit, Guid> _organizationUnits;
        public OrganizationUnitTestDataBuilder(
            IGuidGenerator guidGenerator,
            IRepository<OrganizationUnit, Guid> organizationUnits)
        {
            _guidGenerator = guidGenerator;
            _organizationUnits = organizationUnits;
        }

        public void Build()
        {
            CreateOrganizationUnit();
        }

        private void CreateOrganizationUnit()
        {
            var parentId = _guidGenerator.Create();
            var org1 = new OrganizationUnit(parentId, null, "总公司", null)
            {
                Code = "00001"
            };
            var org2 = new OrganizationUnit(_guidGenerator.Create(), null, "分公司1", parentId)
            {
                Code = "00001.00001"
            };

            var org3 = new OrganizationUnit(_guidGenerator.Create(), null, "分公司2", parentId)
            {
                Code = "00001.00002"
            };
            _organizationUnits.Insert(org1);
            _organizationUnits.Insert(org2);
            _organizationUnits.Insert(org3);
        }
    }
}
