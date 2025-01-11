using MediatR;
using SchoolProject.Core.Features.Instructors.Queries.Responses;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Enums;

namespace SchoolProject.Core.Features.Instructors.Queries.Models
{
    public class GetInstructorPaginatedListQueryModel : IRequest<PaginatedResult<GetInstructorPaginatedListQueryResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public InstructorOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
