using SchoolProject.Core.Features.Instructors.Queries.Responses;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Instructors
{
    public partial class InstructorProfile
    {
        public void GetInstructorPaginationMapping()
        {
            CreateMap<Instructor, GetInstructorPaginatedListQueryResponse>()
                                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
                                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.ENameAr, src.ENameEn)))
                                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Supervisor == null ? "No Manager" : src.Supervisor.Localize(src.Supervisor.ENameAr, src.Supervisor.ENameEn)))
                                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.department == null ? "Not affiliated with any department" : src.department.Localize(src.department.DNameAr, src.department.DNameEn)));

        }
    }
}
