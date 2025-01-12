using MediatR;

namespace SchoolProject.Core.Features.Instructors.Commands.Models
{
    public class DeleteInstructorCommandModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
