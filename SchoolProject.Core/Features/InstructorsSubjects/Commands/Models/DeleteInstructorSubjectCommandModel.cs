using MediatR;

namespace SchoolProject.Core.Features.InstructorsSubjects.Commands.Models
{
    public class DeleteInstructorSubjectCommandModel : IRequest<Response<string>>
    {
        public int InstructorId { get; set; }
        public int SubjectId { get; set; }
    }
}
