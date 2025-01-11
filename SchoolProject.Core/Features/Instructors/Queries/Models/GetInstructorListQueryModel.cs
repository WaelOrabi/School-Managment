using MediatR;
using SchoolProject.Core.Features.Instructors.Queries.Responses;

namespace SchoolProject.Core.Features.Instructors.Queries.Models
{
    public class GetInstructorListQueryModel : IRequest<Response<List<GetInstructorListQueryResponse>>>
    {
    }
}
