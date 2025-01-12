using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Subjects
{
    public partial class SubjectProfile
    {
        public void AddSubjectCommandMapping()
        {
            CreateMap<AddSubjectCommandModel, Subject>()
                                             .ForMember(dest => dest.SubjectNameAr, opt => opt.MapFrom(src => src.NameAr))
                                             .ForMember(dest => dest.SubjectNameEn, opt => opt.MapFrom(src => src.NameEn))
                                             .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period));
        }
    }
}
