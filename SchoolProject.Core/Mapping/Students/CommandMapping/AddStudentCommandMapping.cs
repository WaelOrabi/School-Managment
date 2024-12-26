using AutoMapper;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.Students
{
    public partial class StudentProfile : Profile
    {
        public void AddStudentMapping()
        {
            CreateMap<AddStudentCommand, Student>().ForMember(dest => dest.DID, opt => opt.MapFrom(src=>src.DepartmentId));
        }
    }
}
