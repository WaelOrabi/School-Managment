using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;

namespace SchoolProject.Service.Abstracts
{
    public interface IDepartmentService
    {
        public Task<List<Department>> GetDepartmentListAsync();
        public Task<Department> GetDepartmentById(int id);
        public Task<bool> IsDepartmentIdExist(int DepartmentId);
        public Task<bool> IsIdExist(int id);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<string> AddDepartment(Department department);
        public Task<string> EditDepartment(Department department);
        public Task<string> DeleteDepartment(Department department);
        public IQueryable<Department> FilterDepartmentPaginatedQuerable(DepartmentOrderingEnum departmentOrderingEnum, string search);
    }
}
