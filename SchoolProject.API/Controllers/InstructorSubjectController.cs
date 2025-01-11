using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.InstructorsSubjects.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class InstructorSubjectController : AppControllerBase
    {
        [HttpPost(Router.InstructorSubjectRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddInstructorSubjectCommandModel command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpDelete(Router.InstructorSubjectRouting.Delete)]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int instructorId, [FromRoute] int subjectId)
        {
            var response = await Mediator.Send(new DeleteInstructorSubjectCommandModel() { InstructorId = instructorId, SubjectId = subjectId });
            return NewResult(response);
        }
    }
}
