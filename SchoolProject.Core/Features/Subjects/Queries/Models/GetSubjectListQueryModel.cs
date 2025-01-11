using MediatR;
using SchoolProject.Core.Features.Subjects.Queries.Responses;

namespace SchoolProject.Core.Features.Subjects.Queries.Models
{
    public class GetSubjectListQueryModel : IRequest<Response<List<GetSubjectListQueryResponse>>>
    {
    }
}
