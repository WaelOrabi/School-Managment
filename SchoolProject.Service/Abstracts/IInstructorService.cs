using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;

namespace SchoolProject.Service.Abstracts
{
    public interface IInstructorService
    {
        public Task<string> AddInstructor(Instructor instructor);
        public Task<string> EditInstructor(Instructor instructor);
        public Task<string> DeleteInstructor(Instructor instructor);
        public Task<Instructor> GetInstructorById(int id);
        public Task<bool> IsIdExist(int id);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameEnExist(string nameEn);

        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<bool> IsSupervisorExist(int id);
        public Task<bool> IsInstructorIdExist(int id);
        public Task<List<Instructor>> GetInstructorListAsync();

        public IQueryable<Instructor> FilterInstructorPaginatedQuerable(InstructorOrderingEnum instructorOrderingEnum, string search);
    }
}
