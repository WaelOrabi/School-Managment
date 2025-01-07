using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{

    [ApiController]
    [Authorize]
    public class StudentController : AppControllerBase
    {

        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
            var response = await Mediator.Send(new GetStudentListQuery());
            return NewResult(response);
        }
        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetStudentPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.StudentRouting.GetByID)]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);
        }
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand addStudentCommand)
        {
            var response = await Mediator.Send(addStudentCommand);
            return NewResult(response);
        }
        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand editStudentCommand)
        {
            var response = await Mediator.Send(editStudentCommand);
            return NewResult(response);
        }
        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }
    }
}
