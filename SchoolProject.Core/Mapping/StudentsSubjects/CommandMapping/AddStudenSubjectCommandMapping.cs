using SchoolProject.Core.Features.StudentsSubjects.Commands.Models;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentsSubjects
{
    public partial class StudentSubjectProfile
    {
        public void AddStudenSubjectCommandMapping()
        {
            CreateMap<AddStudentSubjectCommandModel, StudentSubject>();
        }
    }
}
