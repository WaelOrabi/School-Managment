using MediatR;
using SchoolProject.Core.Features.Departments.Queries.Responses;

namespace SchoolProject.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQueryModel : IRequest<Response<GetDepartmentByIdQueryResponse>>
    {
        public int Id { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }

    }
}
