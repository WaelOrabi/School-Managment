using MediatR;
using SchoolProject.Core.Features.Authorization.Queries.Response;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class GetRolesListQuery : IRequest<Response<List<GetRoleResponse>>>
    {
    }
}
