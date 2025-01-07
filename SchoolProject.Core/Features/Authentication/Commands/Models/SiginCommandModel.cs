using MediatR;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class SiginCommandModel : IRequest<Response<JWTAuthResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
