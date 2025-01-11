using SchoolProject.Core.Features.Instructors.Queries.Response;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Instructors
{
    public partial class InstructorProfile
    {
        public void GetInstructorByIdMapping()
        {
            CreateMap<Instructor, GetInstructorByIdQueryResponse>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.ENameAr, src.ENameEn)))
                       .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => src.Supervisor))
                       .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.department))
                       .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.Ins_Subjects));

            CreateMap<Instructor, ManagerResponse>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.ENameAr, src.ENameEn)));


            CreateMap<Department, DepartmentResponse>()
                      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
                      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.DNameAr, src.DNameEn)));

            CreateMap<InstructorSubject, SubjectResponse>()
                      .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Subject.Localize(src.Subject.SubjectNameAr, src.Subject.SubjectNameEn)));

        }
    }
}
