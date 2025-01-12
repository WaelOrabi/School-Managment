using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{

    [ApiController]
    [Authorize()]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetByID)]
        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIdQueryModel query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        [HttpPost(Router.DepartmentRouting.Create)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentCommandModel command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPut(Router.DepartmentRouting.Edit)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditDepartment([FromBody] EditDepartmentCommandModel command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.DepartmentRouting.Delete)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteDepartmentCommandModel() { Id = id });
            return NewResult(response);
        }
        [HttpGet(Router.DepartmentRouting.List)]
        public async Task<IActionResult> GetDepartmentList()
        {
            var response = await Mediator.Send(new GetDepartmentListQueryModel());
            return NewResult(response);
        }
        [HttpGet(Router.DepartmentRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetDepartmentPaginatedListQueryModel query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
    }
}
