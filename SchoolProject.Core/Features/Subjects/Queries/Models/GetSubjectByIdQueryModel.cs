using MediatR;
using SchoolProject.Core.Features.Subjects.Queries.Responses;

namespace SchoolProject.Core.Features.Subjects.Queries.Models
{
    public class GetSubjectByIdQueryModel : IRequest<Response<GetSubjectByIdQueryResponse>>
    {
        public int Id { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }
    }
}
