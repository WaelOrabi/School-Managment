using AutoMapper;

namespace SchoolProject.Core.Mapping.StudentsSubjects
{
    public partial class StudentSubjectProfile : Profile
    {
        public StudentSubjectProfile()
        {
            AddStudenSubjectCommandMapping();
        }
    }
}
