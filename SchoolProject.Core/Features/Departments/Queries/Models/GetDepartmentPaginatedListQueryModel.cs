using MediatR;
using SchoolProject.Core.Features.Departments.Queries.Responses;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Enums;

namespace SchoolProject.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentPaginatedListQueryModel : IRequest<PaginatedResult<GetDepartmentPaginatedListQueryResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DepartmentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
