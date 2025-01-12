using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Data.Entities;


namespace SchoolProject.Core.Mapping.Instructors
{
    public partial class InstructorProfile
    {
        public void AddInstructorCommandMapping()
        {
            CreateMap<AddInstructorCommandModel, Instructor>()
                    .ForMember(dest => dest.ENameAr, opt => opt.MapFrom(src => src.NameAr))
                     .ForMember(dest => dest.ENameEn, opt => opt.MapFrom(src => src.NameEn))
                      .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId));
        }
    }
}
