using MediatR;
using SchoolProject.Data.DTOs;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommandModel : EditRoleRequest, IRequest<Response<string>>
    {

    }
}
