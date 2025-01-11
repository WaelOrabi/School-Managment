using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.StudentsSubjects.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class StudentSubjectController : AppControllerBase
    {
        [HttpPost(Router.StudentSubjectRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddStudentSubjectCommandModel command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
        [HttpPut(Router.StudentSubjectRouting.Edit)]

        public async Task<IActionResult> Edit([FromBody] EditStudentSubjectCommandModel command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.StudentSubjectRouting.Delete)]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int studentId, [FromRoute] int subjectId)
        {
            var response = await Mediator.Send(new DeleteStudentSubjectCommandModel() { StudentId = studentId, SubjectId = subjectId });
            return NewResult(response);
        }
    }
}
