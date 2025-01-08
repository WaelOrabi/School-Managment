using MediatR;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class AddRoleCommandModel : IRequest<Response<string>>
    {
        public string RoleName { get; set; }
    }
}
