using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;
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

        public async Task<bool> IsNameArExist(string nameAr)
        {
            var department = await _departmentRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.DNameAr.Equals(nameAr));
            if (department == null) return false;
            return true;
        }

        public async Task<bool> IsNameEnExist(string nameEn)
        {
            var department = await _departmentRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.DNameEn.Equals(nameEn));
            if (department == null) return false;
            return true;
        }

        public async Task<string> AddDepartment(Department department)
        {
            await _departmentRepository.AddAsync(department);
            return "Success";
        }
        public async Task<string> EditDepartment(Department department)
        {
            await _departmentRepository.UpdateAsync(department);
            return "Success";
        }
        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {
            var department = await _departmentRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.DNameAr.Equals(nameAr) & !x.DID.Equals(id));
            if (department == null) return false;
            return true;
        }

        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            var department = await _departmentRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.DNameEn.Equals(nameEn) & !x.DID.Equals(id));
            if (department == null) return false;
            return true;
        }

        public async Task<string> DeleteDepartment(Department department)
        {

            await _departmentRepository.DeleteAsync(department);
            return "Success";
        }

        public async Task<List<Department>> GetDepartmentListAsync()
        {
            return await _departmentRepository.GetTableNoTracking().Include(x => x.InstructorManager).ToListAsync();
        }

        public IQueryable<Department> FilterDepartmentPaginatedQuerable(DepartmentOrderingEnum departmentOrderingEnum, string search)
        {
            var querable = _departmentRepository.GetTableNoTracking().Include(x => x.InstructorManager).AsQueryable();
            if (search != null)
                querable = querable.Where(x => x.DNameEn.Contains(search) || x.DNameAr.Contains(search) || x.InstructorManager.ENameAr.Contains(search) || x.InstructorManager.ENameEn.Contains(search));
            switch (departmentOrderingEnum)
            {
                case DepartmentOrderingEnum.ID:
                    querable = querable.OrderBy(x => x.DID);
                    break;
                case DepartmentOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.DNameEn);
                    break;
                case DepartmentOrderingEnum.ManagerName:
                    querable = querable.OrderBy(x => x.InstructorManager.ENameEn);
                    break;

            }
            return querable;
        }

        public async Task<bool> IsIdExist(int id)
        {
            return await _departmentRepository.GetTableNoTracking().AnyAsync(x => x.DID.Equals(id));
        }


        #endregion
    }
}
