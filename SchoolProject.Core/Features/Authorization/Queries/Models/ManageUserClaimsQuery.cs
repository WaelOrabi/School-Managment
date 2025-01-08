using MediatR;
using SchoolProject.Data.Responses;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResponse>>
    {
        public int UserId { get; set; }
    }
}
