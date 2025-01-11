using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts
{
    public interface IInstructorSubjectService
    {
        public Task<string> AddInstructorSubject(InstructorSubject instructorSubject);
        public Task<string> DeleteInstructorSubject(int instructorId, int subjectId);
    }
}
