using SchoolProject.Core.Features.Subjects.Queries.Responses;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Subjects
{
    public partial class SubjectProfile
    {
        public void GetSubjectListMapping()
        {
            CreateMap<Subject, GetSubjectListQueryResponse>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.SubjectNameAr, src.SubjectNameEn)))
                   .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period));
        }
    }
}
