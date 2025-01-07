using MediatR;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommandModel : IRequest<Response<JWTAuthResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
