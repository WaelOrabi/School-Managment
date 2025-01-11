using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class StudentSubjectService : IStudentSubjectService
    {
        private readonly IStudentSubjectRepository _studentSubjectRepository;
        public StudentSubjectService(IStudentSubjectRepository studentSubjectRepository)
        {
            _studentSubjectRepository = studentSubjectRepository;
        }
        public async Task<string> AddStudentSubject(StudentSubject studentSubject)
        {
            await _studentSubjectRepository.AddAsync(studentSubject);
            return "Success";
        }

        public async Task<string> DeleteStudentSubject(int studentId, int subjectId)
        {
            var studentSubject = await _studentSubjectRepository.GetTableNoTracking()
            .FirstOrDefaultAsync(ss => ss.StudID == studentId && ss.SubID == subjectId);

            if (studentSubject == null)
                return "Failed";
            await _studentSubjectRepository.DeleteAsync(studentSubject);
            return "Success";
        }

        public async Task<string> EditStudentSubject(StudentSubject studentSubject)
        {
            var result = await _studentSubjectRepository.GetTableAsTracking().FirstOrDefaultAsync(x => x.StudID.Equals(studentSubject.StudID) && x.SubID.Equals(studentSubject.SubID));
            result.Grade = studentSubject.Grade;
            await _studentSubjectRepository.SaveChangesAsync();
            if (result == null)
                return "Failed";
            return "Success";
        }
    }
}
