using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Data.AppMetaData;
namespace SchoolProject.API.Controllers
{

    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommandModel command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
