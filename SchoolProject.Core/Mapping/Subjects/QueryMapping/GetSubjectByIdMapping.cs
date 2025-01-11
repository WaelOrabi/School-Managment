using SchoolProject.Core.Features.Subjects.Queries.Responses;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Subjects
{
    public partial class SubjectProfile
    {
        public void GetSubjectByIdMapping()
        {
            CreateMap<Subject, GetSubjectByIdQueryResponse>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.SubjectNameAr, src.SubjectNameEn)))
               .ForMember(dest => dest.Period, opt => opt.MapFrom(src => src.Period))
               .ForMember(dest => dest.StudentsSubject, opt => opt.MapFrom(src => src.StudentsSubjects))
               .ForMember(dest => dest.DepartmetsSubject, opt => opt.MapFrom(src => src.DepartmetsSubjects))
               .ForMember(dest => dest.InstructorsSubject, opt => opt.MapFrom(src => src.Ins_Subjects));

            CreateMap<DepartmentSubject, DepartmentSubjectResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Department.Localize(src.Department.DNameAr, src.Department.DNameEn)));

            CreateMap<StudentSubject, StudentSubjectResponse>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudID))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Student.Localize(src.Student.NameAr, src.Student.NameEn)));

            CreateMap<InstructorSubject, InstructorSubjectResponse>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Instructor.Localize(src.Instructor.ENameAr, src.Instructor.ENameEn)));
        }
    }
}
