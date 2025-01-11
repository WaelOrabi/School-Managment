using MediatR;

namespace SchoolProject.Core.Features.DepartmentsSubjects.Commands.Models
{
    public class DeleteDepartmentSubjectCommandModel : IRequest<Response<string>>
    {
        public int DepartmentId { get; set; }
        public int SubjectId { get; set; }
    }
}
