using MediatR;
using SchoolProject.Data.Responses;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommandModel : IRequest<Response<JWTAuthResponse>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
