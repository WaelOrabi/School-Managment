using MediatR;

namespace SchoolProject.Core.Features.Departments.Commands.Models
{
    public class DeleteDepartmentCommandModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
