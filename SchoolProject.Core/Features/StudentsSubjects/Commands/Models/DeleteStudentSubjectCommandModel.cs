using MediatR;

namespace SchoolProject.Core.Features.StudentsSubjects.Commands.Models
{
    public class DeleteStudentSubjectCommandModel : IRequest<Response<string>>
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
    }
}
