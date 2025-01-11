using MediatR;
using SchoolProject.Core.Features.Departments.Queries.Responses;

namespace SchoolProject.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentListQueryModel : IRequest<Response<List<GetDepartmentListQueryResponse>>>
    {

    }
}
