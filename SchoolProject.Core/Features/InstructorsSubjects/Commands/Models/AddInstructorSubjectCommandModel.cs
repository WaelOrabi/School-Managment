using MediatR;

namespace SchoolProject.Core.Features.InstructorsSubjects.Commands.Models
{
    public class AddInstructorSubjectCommandModel : IRequest<Response<string>>
    {
        public int InstructorId { get; set; }
        public int SubjectId { get; set; }
    }
}
