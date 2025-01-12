using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Enums;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion
        #region constructors
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        #endregion

        #region Handle Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetTableNoTracking().Include(x => x.Department).ToListAsync();
        }
        public async Task<Student> GetStudentByIdWithIncludeAsync(int id)
        {

            var student = _studentRepository.GetTableNoTracking().Include(x => x.Department).Where(x => x.StudID.Equals(id)).FirstOrDefault();
            return student;
        }

        public async Task<string> AddAsync(Student student)
        {

            await _studentRepository.AddAsync(student);
            return "Success";
        }


        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Falied";
            }

        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);

        }

        public IQueryable<Student> GetStudentsQuerable()
        {
            return _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum studentOrderingEnum, string search)
        {
            var querable = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (search != null)
                querable = querable.Where(x => x.NameEn.Contains(search) || x.NameAr.Contains(search) || x.Department.DNameEn.Contains(search) || x.Department.DNameAr.Contains(search) || x.Address.Contains(search));
            switch (studentOrderingEnum)
            {
                case StudentOrderingEnum.StudID:
                    querable = querable.OrderBy(x => x.StudID);
                    break;
                case StudentOrderingEnum.Name:
                    querable = querable.OrderBy(x => x.NameEn);
                    break;
                case StudentOrderingEnum.DepartmentName:
                    querable = querable.OrderBy(x => x.Department.DNameEn);
                    break;
                case StudentOrderingEnum.Address:
                    querable = querable.OrderBy(x => x.Address);
                    break;
            }
            return querable;
        }

        public IQueryable<Student> GetStudentsByDepartmentIdQuerable(int DID)
        {
            return _studentRepository.GetTableNoTracking().Where(x => x.DID.Equals(DID)).AsQueryable();
        }
        public IQueryable<Student> GetStudentsBySubjectIdQuerable(int subjectId)
        {
            return _studentRepository.GetTableNoTracking()
                                     .Include(x => x.StudentsSubjects)
                                     .Where(x => x.StudentsSubjects.Any(ss => ss.SubID == subjectId))
                                     .AsQueryable();
        }

        public async Task<bool> IsNameArExist(string nameAr)
        {

            var student = _studentRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }



        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {

            var student = await _studentRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(nameAr) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameEnExist(string nameEn)
        {

            var student = _studentRepository.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {

            var student = await _studentRepository.GetTableNoTracking().Where(x => x.NameEn.Equals(nameEn) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsIdExist(int id)
        {
            return await _studentRepository.GetTableNoTracking().AnyAsync(x => x.StudID.Equals(id));
        }


        #endregion

    }
}
