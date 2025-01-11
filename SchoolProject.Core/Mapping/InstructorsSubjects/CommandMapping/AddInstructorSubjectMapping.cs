using SchoolProject.Core.Features.InstructorsSubjects.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.InstructorsSubjects
{
    public partial class InstructorSubjectProfile
    {
        public void AddInstructorSubjectMapping()
        {
            CreateMap<AddInstructorSubjectCommandModel, InstructorSubject>()
                  .ForMember(dest => dest.InsId, opt => opt.MapFrom(src => src.InstructorId))
                  .ForMember(dest => dest.SubID, opt => opt.MapFrom(src => src.SubjectId));
        }
    }
}
