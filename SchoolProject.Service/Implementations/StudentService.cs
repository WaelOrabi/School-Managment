using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Commons;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;
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
            return await _studentRepository.GetStudentsListAsync();
        }
        public async Task<Student> GetStudentByIdWithIncludeAsync(int id)
        {
            //  return await _studentRepository.GetByIdAsync(id);
            var student = _studentRepository.GetTableNoTracking().Include(x => x.Department).Where(x => x.StudID.Equals(id)).FirstOrDefault();
            return student;
        }

        public async Task<string> AddAsync(Student student)
        {
            //Check if the name is Exist Or not 
            //    var studentResult=_studentRepository.GetTabkeNoTracking().Where(x=>x.Name.Equals(student.Name)).FirstOrDefault();
            //     if (studentResult != null) return "Exist";

            //Added Student
            await _studentRepository.AddAsync(student);
            return "Success";
        }

        //public async Task<bool> IsNameExist(string name)
        //{
        //    var student = await _studentRepository.GetTableNoTracking().Where(x => x.Localize(x.NameAr, x.NameEn).Equals(name)).FirstOrDefaultAsync();
        //    if (student == null) return false;
        //    return true;
        //}
        public async Task<bool> IsNameExist(string name)
        {
            var students = await _studentRepository.GetTableNoTracking().ToListAsync(); // Fetch data from the database
            var student = students.FirstOrDefault(x =>
                new GeneralLocalizableEntity().Localize(x.NameAr, x.NameEn).Equals(name, StringComparison.OrdinalIgnoreCase));
            return student != null;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            var student = await _studentRepository.GetTableNoTracking().Where(x => x.Localize(x.NameAr, x.NameEn).Equals(name) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
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
                querable = querable.Where(x => x.NameEn.Contains(search) || x.Address.Contains(search));
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
        #endregion

    }
}
