using MediatR;
using SchoolProject.Core.Features.Instructors.Queries.Response;

namespace SchoolProject.Core.Features.Instructors.Queries.Models
{
    public class GetInstructorByIdQueryModel : IRequest<Response<GetInstructorByIdQueryResponse>>
    {
        public int Id { get; set; }
    }
}
