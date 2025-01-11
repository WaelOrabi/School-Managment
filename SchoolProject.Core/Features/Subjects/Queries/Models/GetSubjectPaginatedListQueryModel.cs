using MediatR;
using SchoolProject.Core.Features.Subjects.Queries.Responses;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Enums;

namespace SchoolProject.Core.Features.Subjects.Queries.Models
{
    public class GetSubjectPaginatedListQueryModel : IRequest<PaginatedResult<GetSubjectPaginatedListQueryResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public SubjectOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
