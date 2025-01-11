using MediatR;

namespace SchoolProject.Core.Features.StudentsSubjects.Commands.Models
{
    public class EditStudentSubjectCommandModel : AddStudentSubjectCommandModel, IRequest<Response<string>>
    {

    }
}
