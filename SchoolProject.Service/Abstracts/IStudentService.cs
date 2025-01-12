using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdWithIncludeAsync(int id);
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<bool>IsIdExist(int id);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        public IQueryable<Student> GetStudentsQuerable();
        public IQueryable<Student> GetStudentsByDepartmentIdQuerable(int DID);
        public IQueryable<Student> GetStudentsBySubjectIdQuerable(int subjectId);
        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum studentOrderingEnum, string search);
    }
}
