using SchoolProject.Data.Entities;
using SchoolProject.infrastructure.InfrastructureBases;

namespace SchoolProject.infrastructure.Abstracts
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        //      public Task<List<Student>> GetStudentsListAsync();
    }
}
