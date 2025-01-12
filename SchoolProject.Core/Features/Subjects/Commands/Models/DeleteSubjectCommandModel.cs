using MediatR;

namespace SchoolProject.Core.Features.Subjects.Commands.Models
{
    public class DeleteSubjectCommandModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
