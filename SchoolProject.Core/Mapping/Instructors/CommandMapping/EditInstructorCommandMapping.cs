using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Instructors
{
    public partial class InstructorProfile
    {
        public void EditInstructorCommandMapping()
        {
            CreateMap<EditInstructorCommandModel, Instructor>()
                      .ForMember(dest => dest.InsId, opt => opt.MapFrom(src => src.Id))
                      .ForMember(dest => dest.ENameAr, opt => opt.MapFrom(src => src.NameAr))
                      .ForMember(dest => dest.ENameEn, opt => opt.MapFrom(src => src.NameEn))
                      .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId));
        }
    }
}
