using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts
{
    public interface IDepartmentSubjectService
    {
        public Task<string> AddDepartmentSubject(DepartmentSubject departmentSubject);
        public Task<string> DeleteDepartmentSubject(int departmentId, int subjectId);
    }
}
