using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{

    public class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        public AddStudentCommandValidator(IStudentService studentService, IStringLocalizer<SharedResources> localizer)
        {
            _studentService = studentService;
            _localizer = localizer;
            ApplayValidationsRules();
            ApplayCustomValidationsRules();
        }


        #region Actions
        public void ApplayValidationsRules()
        {
            RuleFor(x => x.NameAr).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage("NameAr Must not Be Null")
            .MaximumLength(100).WithMessage("Max Length is 10");
            RuleFor(x => x.NameEn).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
        .NotNull().WithMessage("NameEn Must not Be Null")
        .MaximumLength(100).WithMessage("Max Length is 10");

            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} Must not Be Empty")
           .NotNull().WithMessage("{PropertyName} Must not Be Null")
           .MaximumLength(100).WithMessage("{PropertyName} Length is 10");
        }
        public void ApplayCustomValidationsRules()
        {
            RuleFor(x => x.NameAr).MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key)).WithMessage("NameAr is Exist");
            RuleFor(x => x.NameEn).MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key)).WithMessage("NameEn is Exist");

        }
        #endregion
    }
}
