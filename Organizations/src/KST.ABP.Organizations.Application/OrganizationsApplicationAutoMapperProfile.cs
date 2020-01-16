using AutoMapper;
using KST.ABP.Organizations.Dto;
using KST.ABP.Organizations.User;

namespace KST.ABP.Organizations
{
    public class OrganizationsApplicationAutoMapperProfile : Profile
    {
        public OrganizationsApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<OrganizationUnit, OrganizationUnitDto>(memberList: MemberList.Destination)
               .ForMember(m => m.MemberCount, m => m.Ignore());

            CreateMap<OrganizationUnitUser, OrganizationUnitUserListDto>(MemberList.Destination)
                .ForMember(m => m.AddTime, m => m.Ignore());
        }
    }
}