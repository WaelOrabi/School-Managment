using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class InstructorSubjectService : IInstructorSubjectService
    {
        private readonly IInstructorSubjectRepository _instructorSubjectRepository;
        public InstructorSubjectService(IInstructorSubjectRepository instructorSubjectRepository)
        {
            _instructorSubjectRepository = instructorSubjectRepository;
        }
        public async Task<string> AddInstructorSubject(InstructorSubject instructorSubject)
        {
            await _instructorSubjectRepository.AddAsync(instructorSubject);
            return "Success";
        }

        public async Task<string> DeleteInstructorSubject(int instructorId, int subjectId)
        {
            var departmentSubject = await _instructorSubjectRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.InsId.Equals(instructorId) && x.SubID.Equals(subjectId));

            if (departmentSubject == null)
                return "Failed";
            await _instructorSubjectRepository.DeleteAsync(departmentSubject);
            return "Success";
        }
    }
}
