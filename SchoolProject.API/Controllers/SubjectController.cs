using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Features.Subjects.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{

    [ApiController]
    [Authorize()]
    public class SubjectController : AppControllerBase
    {
        [HttpPost(Router.SubjectRouting.Create)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] AddSubjectCommandModel command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
        [HttpPut(Router.SubjectRouting.Edit)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditDepartment([FromBody] EditSubjectCommandModel command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.SubjectRouting.Delete)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteSubjectCommandModel() { Id = id });
            return NewResult(response);
        }
        [HttpGet(Router.SubjectRouting.GetByID)]
        public async Task<IActionResult> GetSubjectById([FromQuery] GetSubjectByIdQueryModel query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        [HttpGet(Router.SubjectRouting.List)]
        public async Task<IActionResult> GetSubjectList()
        {
            var response = await Mediator.Send(new GetSubjectListQueryModel());
            return NewResult(response);
        }
        [HttpGet(Router.SubjectRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetSubjectPaginatedListQueryModel query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
