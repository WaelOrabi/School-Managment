namespace SchoolProject.Core.Features.Instructors.Queries.Responses
{
    public class GetInstructorListQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Position { get; set; }
        public string? ManagerName { get; set; }
        public string? DepartmentName { get; set; }
    }
}
