using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class EditStudentCommandValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;
        public EditStudentCommandValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplayValidationsRules();
            ApplayCustomValidationsRules();
        }


        #region Actions
        public void ApplayValidationsRules()
        {
            RuleFor(x => x.NameAr).NotEmpty().WithMessage("NameAr Must not Be Empty")
            .NotNull().WithMessage("Name Must not Be Null")
            .MaximumLength(100).WithMessage("Max Length is 10");
            RuleFor(x => x.NameEn).NotEmpty().WithMessage("NameEn Must not Be Empty")
      .NotNull().WithMessage("Name Must not Be Null")
      .MaximumLength(100).WithMessage("Max Length is 10");

            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} Must not Be Empty")
           .NotNull().WithMessage("{PropertyName} Must not Be Null")
           .MaximumLength(100).WithMessage("{PropertyName} Length is 10");
        }
        public void ApplayCustomValidationsRules()
        {
            RuleFor(x => x.NameAr).MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(key, model.Id)).WithMessage("NameAr is Exist");
            RuleFor(x => x.NameEn).MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(key, model.Id)).WithMessage("NameEn is Exist");

        }
        #endregion
    }
}
