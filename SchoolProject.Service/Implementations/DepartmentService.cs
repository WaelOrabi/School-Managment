using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        #region Fields
        private readonly IDepartmentRepository _departmentRepository;
        #endregion
        #region Constructors
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        #endregion
        #region Handle Functions

        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetTableNoTracking().Where(x => x.DID.Equals(id))
                                                                            .Include(x => x.DepartmetsSubjects).ThenInclude(x => x.Subject)
                                                                            //  .Include(x => x.Students)
                                                                            .Include(x => x.Instructors)
                                                                            .Include(x => x.InstructorManager).FirstOrDefaultAsync();
            return department;
        }

        public async Task<bool> IsDepartmentIdExist(int DepartmentId)
        {
            return await _departmentRepository.GetTableNoTracking().AnyAsync(x => x.DID.Equals(DepartmentId));
        }
        #endregion
    }
}
