using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Subjects.Queries.Responses
{
    public class GetSubjectByIdQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Period { get; set; }
        public PaginatedResult<StudentSubjectResponse> StudentsSubject { get; set; }
        public List<DepartmentSubjectResponse> DepartmetsSubject { get; set; }
        public List<InstructorSubjectResponse> InstructorsSubject { get; set; }
    }
    public class StudentSubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DepartmentSubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class InstructorSubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
