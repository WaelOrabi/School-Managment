using MediatR;

namespace SchoolProject.Core.Features.DepartmentsSubjects.Commands.Models
{
    public class AddDepartmentSubjectCommandModel : IRequest<Response<string>>
    {
        public int DepartmentID { get; set; }

        public int SubjectID { get; set; }
    }
}
