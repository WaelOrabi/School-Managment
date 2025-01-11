using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;

namespace SchoolProject.Service.Abstracts
{
    public interface ISubjectService
    {
        public Task<string> AddSubject(Subject subject);
        public Task<string> EditSubject(Subject subject);
        public Task<string> DeleteSubject(Subject subject);
        public Task<List<Subject>> GetSubjectListAsync();
        public Task<Subject> GetSubjectById(int id);
        public Task<bool> IsIdExist(int id);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<bool> IsSubjectIdExist(int id);
        public IQueryable<Subject> FilterSubjectPaginatedQuerable(SubjectOrderingEnum subjectOrderingEnum, string? search);
    }
}
