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
        private readonly IDepartmentService _departmentService;
        #endregion

        public AddStudentCommandValidator(IStudentService studentService, IStringLocalizer<SharedResources> localizer, IDepartmentService departmentService)
        {
            _studentService = studentService;
            _localizer = localizer;
            _departmentService = departmentService;
            ApplayValidationsRules();
            ApplayCustomValidationsRules();
        }


        #region Actions
        public void ApplayValidationsRules()
        {
            RuleFor(x => x.NameAr).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.NameEn).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);

            RuleFor(x => x.Address).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
           .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);

            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
        }
        public void ApplayCustomValidationsRules()
        {
            RuleFor(x => x.NameAr).MustAsync(async (key, CancellationToken) => !await _studentService.IsNameArExist(key)).WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn).MustAsync(async (key, CancellationToken) => !await _studentService.IsNameEnExist(key)).WithMessage(_localizer[SharedResourcesKeys.IsExist]);


            RuleFor(x => x.DepartmentId).MustAsync(async (key, CancellationToken) => await _departmentService.IsDepartmentIdExist(key)).WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);

        }
        #endregion
    }
}
