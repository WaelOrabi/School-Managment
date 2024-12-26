using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile
    {
        public void GetStudentMapping()
        {
            CreateMap<Student, GetStudentResponse>().ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
        }
    }
}