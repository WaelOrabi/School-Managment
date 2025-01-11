namespace SchoolProject.Core.Features.Instructors.Queries.Response
{
    public class GetInstructorByIdQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public ManagerResponse Manager { get; set; }
        public DepartmentResponse Department { get; set; }
        public List<SubjectResponse>? SubjectList { get; set; }
    }
    public class ManagerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class DepartmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
