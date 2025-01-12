using Microsoft.EntityFrameworkCore;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class DepartmentSubjectService : IDepartmentSubjectService
    {
        private readonly IDepartmentSubjectRepository _departmentSubjectRepository;
        public DepartmentSubjectService(IDepartmentSubjectRepository departmentSubjectRepository)
        {
            _departmentSubjectRepository = departmentSubjectRepository;
        }



        public async Task<string> AddDepartmentSubject(Data.Entities.DepartmentSubject departmentSubject)
        {
            await _departmentSubjectRepository.AddAsync(departmentSubject);
            return "Success";
        }

        public async Task<string> DeleteDepartmentSubject(int departmentId, int subjectId)
        {
            var departmentSubject = await _departmentSubjectRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.DID.Equals(departmentId) && x.SubID.Equals(subjectId));

            if (departmentSubject == null)
                return "Failed";
            await _departmentSubjectRepository.DeleteAsync(departmentSubject);
            return "Success";
        }




    }
}
