using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Features.ApplicationUser.Queries.Models;
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
        [HttpGet(Router.ApplicationUserRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetUserPaginationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.ApplicationUserRouting.GetById)]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }
        [HttpPut(Router.ApplicationUserRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditUserCommandModel query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
    }
}
