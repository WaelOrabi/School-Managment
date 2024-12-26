using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
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
            var student = _studentRepository.GetTabkeNoTracking().Include(x => x.Department).Where(x => x.StudID.Equals(id)).FirstOrDefault();
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

        public async Task<bool> IsNameExist(string name)
        {
            var student = await _studentRepository.GetTabkeNoTracking().Where(x => x.Name == name).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            var student = await _studentRepository.GetTabkeNoTracking().Where(x => x.Name.Equals(name) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
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
        #endregion

    }
}
