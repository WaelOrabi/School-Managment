using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<string> AddInstructor(Instructor instructor)
        {
            await _instructorRepository.AddAsync(instructor);
            return "Success";
        }



        public async Task<string> EditInstructor(Instructor instructor)
        {
            await _instructorRepository.UpdateAsync(instructor);
            return "Success";
        }
        public async Task<string> DeleteInstructor(Instructor instructor)
        {
            await _instructorRepository.DeleteAsync(instructor);

            return "Success";
        }
        public async Task<bool> IsInstructorIdExist(int id)
        {
            var result = await _instructorRepository.GetTableNoTracking().AnyAsync(x => x.InsId.Equals(id));
            return result;
        }

        public async Task<bool> IsNameArExist(string nameAr)
        {
            return await _instructorRepository.GetTableNoTracking().AnyAsync(x => x.ENameAr.Equals(nameAr));
        }

        public async Task<bool> IsNameEnExist(string nameEn)
        {
            return await _instructorRepository.GetTableNoTracking().AnyAsync(x => x.ENameEn.Equals(nameEn));
        }

        public async Task<bool> IsSupervisorExist(int id)
        {
            return await _instructorRepository.GetTableNoTracking().AnyAsync(x => x.InsId.Equals(id));
        }

        public async Task<Instructor> GetInstructorById(int id)
        {
            var instructor = await _instructorRepository.GetTableNoTracking().Include(x => x.department)
                                                                             .Include(x => x.Supervisor)
                                                                             .Include(x => x.Ins_Subjects).ThenInclude(x => x.Subject)
                                                                             .FirstOrDefaultAsync(x => x.InsId.Equals(id));
            return instructor;
        }

        public async Task<List<Instructor>> GetInstructorListAsync()
        {
            return await _instructorRepository.GetTableNoTracking().Include(x => x.Supervisor).Include(x => x.department).ToListAsync();
        }

        public IQueryable<Instructor> FilterInstructorPaginatedQuerable(InstructorOrderingEnum instructorOrderingEnum, string search)
        {
            var querable = _instructorRepository.GetTableNoTracking().AsQueryable();
            if (search != null)
                querable = querable.Where(x => x.ENameEn.Contains(search) ||
                                          x.ENameAr.Contains(search) ||
                                          x.Supervisor.ENameAr.Contains(search) ||
                                          x.Supervisor.ENameEn.Contains(search) ||
                                          x.department.DNameEn.Contains(search) ||
                                          x.department.DNameAr.Contains(search) ||
                                          x.Position.Contains(search) ||
                                          x.Address.Contains(search));
            switch (instructorOrderingEnum)
            {
                case InstructorOrderingEnum.ID:
                    querable = querable.OrderBy(x => x.DID);
                    break;
                case InstructorOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.ENameEn);
                    break;
                case InstructorOrderingEnum.Address:
                    querable = querable.OrderBy(x => x.Address);
                    break;
                case InstructorOrderingEnum.Position:
                    querable = querable.OrderBy(x => x.Position);
                    break;
                case InstructorOrderingEnum.Salary:
                    querable.OrderBy(x => x.Salary);
                    break;
                case InstructorOrderingEnum.Department:
                    querable.OrderBy(x => x.department);
                    break;

            }
            return querable;
        }

        public async Task<bool> IsIdExist(int id)
        {
            return await _instructorRepository.GetTableNoTracking().AnyAsync(x => x.InsId.Equals(id));
        }

        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {

            var student = await _instructorRepository.GetTableNoTracking().Where(x => x.ENameAr.Equals(nameAr) & !x.InsId.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {

            var student = await _instructorRepository.GetTableNoTracking().Where(x => x.ENameEn.Equals(nameEn) & !x.InsId.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }
    }
}
