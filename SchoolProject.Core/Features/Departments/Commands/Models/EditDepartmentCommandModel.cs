using MediatR;

namespace SchoolProject.Core.Features.Departments.Commands.Models
{
    public class EditDepartmentCommandModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int? ManagerId { get; set; }
    }
}
