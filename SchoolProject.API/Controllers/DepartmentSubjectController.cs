using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.DepartmentsSubjects.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DepartmentSubjectController : AppControllerBase
    {
        [HttpPost(Router.DepartmentSubjectRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddDepartmentSubjectCommandModel command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpDelete(Router.DepartmentSubjectRouting.Delete)]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int departmentId, [FromRoute] int subjectId)
        {
            var response = await Mediator.Send(new DeleteDepartmentSubjectCommandModel() { DepartmentId = departmentId, SubjectId = subjectId });
            return NewResult(response);
        }
    }
}
