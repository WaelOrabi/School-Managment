using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{

    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetByID)]
        //public async Task<IActionResult> GetDepartmentById(int id)
        //{
        //    var response = await Mediator.Send(new GetDepartmentByIdQueryModel(id));
        //    return NewResult(response);
        //}
        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIdQueryModel query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
    }
}
