using SchoolProject.Core.Features.Departments.Queries.Responses;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Departments
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentListMapping()
        {
            CreateMap<Department, GetDepartmentListQueryResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.DNameAr, src.DNameEn)))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.InstructorManager.Localize(src.InstructorManager.ENameAr, src.InstructorManager.ENameEn)));
        }
    }
}
