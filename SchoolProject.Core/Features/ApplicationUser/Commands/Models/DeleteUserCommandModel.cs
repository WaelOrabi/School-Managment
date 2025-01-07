using MediatR;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Models
{
    public class DeleteUserCommandModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteUserCommandModel(int id)
        {
            Id = id;
        }
    }
}
