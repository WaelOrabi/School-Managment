using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        public AddStudentCommandValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplayValidationsRules();
            ApplayCustomValidationsRules();
        }


        #region Actions
        public void ApplayValidationsRules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Must not Be Empty")
            .NotNull().WithMessage("Name Must not Be Null")
            .MaximumLength(100).WithMessage("Max Length is 10");

            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} Must not Be Empty")
           .NotNull().WithMessage("{PropertyName} Must not Be Null")
           .MaximumLength(100).WithMessage("{PropertyName} Length is 10");
        }
        public void ApplayCustomValidationsRules()
        {
            RuleFor(x => x.Name).MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key)).WithMessage("Name is Exist");
        }
        #endregion
    }
}
