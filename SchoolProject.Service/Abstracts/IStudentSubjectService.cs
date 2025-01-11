using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentSubjectService
    {
        public Task<string> AddStudentSubject(StudentSubject studentSubject);
        public Task<string> EditStudentSubject(StudentSubject studentSubject);
        public Task<string> DeleteStudentSubject(int studentId, int subjectId);
    }
}
