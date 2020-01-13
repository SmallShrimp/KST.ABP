using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using KST.ABP.Organizations.Dto;

namespace KST.ABP.Organizations.OrganizationUnitTest
{
    public class OrganizationUnitService_Tests : OrganizationsApplicationTestBase
    {

        private readonly IOrganizationUnitAppService organizationUnitAppService;
        public OrganizationUnitService_Tests()
        {
            organizationUnitAppService = GetRequiredService<IOrganizationUnitAppService>();
        }

        [Fact]
        public async Task CreateOrganizationUnit()
        {
            var input = new Dto.CreateOrganizationUnitInput
            {
                DisplayName = "禾斗科技"
            };
            var result = await organizationUnitAppService.CreateOrganizationUnit(input);

            result.Id.ShouldNotBe(Guid.Empty);
            result.ParentId.ShouldBeNull();
            result.Code.ShouldBe("00002");

            var input2 = new Dto.CreateOrganizationUnitInput
            {
                ParentId = result.Id,
                DisplayName = "开发部"
            };
            var result2 = await organizationUnitAppService.CreateOrganizationUnit(input2);
            result2.ParentId.ShouldBe(result.Id);
            result2.Code.ShouldBe("00002.00001");

            var input3 = new Dto.CreateOrganizationUnitInput
            {
                ParentId = result.Id,
                DisplayName = "前端"
            };
            var result3 = await organizationUnitAppService.CreateOrganizationUnit(input3);
            result3.ParentId.ShouldBe(result.Id);
            result3.Code.ShouldBe("00002.00002");

        }

        [Fact]
        public async Task UpdateOrganizationUnit()
        {

        }
    }
}
