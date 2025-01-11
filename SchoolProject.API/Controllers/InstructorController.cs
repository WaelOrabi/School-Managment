using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Features.Instructors.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{

    [ApiController]
    [Authorize()]
    public class InstructorController : AppControllerBase
    {
        [HttpPost(Router.InstructorRouting.Create)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddInstructorCommandModel command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
        [HttpPut(Router.InstructorRouting.Edit)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit([FromBody] EditInstructorCommandModel command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
        [HttpDelete(Router.InstructorRouting.Delete)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await Mediator.Send(new DeleteInstructorCommandModel() { Id = id });
            return NewResult(result);
        }
        [HttpGet(Router.InstructorRouting.GetByID)]
        public async Task<IActionResult> GetInstructorById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetInstructorByIdQueryModel() { Id = id });
            return NewResult(response);
        }
        [HttpGet(Router.InstructorRouting.List)]
        public async Task<IActionResult> GetInstructorList()
        {
            var response = await Mediator.Send(new GetInstructorListQueryModel());
            return NewResult(response);
        }
        [HttpGet(Router.InstructorRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetInstructorPaginatedListQueryModel query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
