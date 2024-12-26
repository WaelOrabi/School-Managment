using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.Abstracts;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<Student> GetStudentByIdAsync(int id)
        {
          //  return await _studentRepository.GetByIdAsync(id);
          var student=_studentRepository.GetTabkeNoTracking().Include(x=>x.Department).Where(x=>x.StudID.Equals(id)).FirstOrDefault();
            return student;
        }

        public async Task<string> AddAsync(Student student)
        {
            //Check if the name is Exist Or not 
            var studentResult=_studentRepository.GetTabkeNoTracking().Where(x=>x.Name.Equals(student.Name)).FirstOrDefault();
            if (studentResult != null) return "Exist";

            //Added Student
            await _studentRepository.AddAsync(student);
            return "Success";
        }
        #endregion

    }
}
