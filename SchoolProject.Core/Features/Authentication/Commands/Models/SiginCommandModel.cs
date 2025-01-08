using MediatR;
using SchoolProject.Data.Responses;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class SiginCommandModel : IRequest<Response<JWTAuthResponse>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
