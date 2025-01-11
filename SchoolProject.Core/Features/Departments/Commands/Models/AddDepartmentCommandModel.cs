using MediatR;

namespace SchoolProject.Core.Features.Departments.Commands.Models
{
    public class AddDepartmentCommandModel : IRequest<Response<string>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int? ManagerId { get; set; }
    }
}

