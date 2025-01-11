using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Departments.Commands.Validations
{
    public class EditDepartmentCommandValidator : AbstractValidator<EditDepartmentCommandModel>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentService _departmentService;
        private readonly IInstructorService _instructorService;

        #endregion
        #region Constructor
        public EditDepartmentCommandValidator(IStringLocalizer<SharedResources> localizer, IDepartmentService departmentService, IInstructorService instructorService)
        {
            _localizer = localizer;
            _departmentService = departmentService;
            _instructorService = instructorService;
            ApplayValidationsRules();
            ApplayCustomValidationsRules();

        }



        #endregion
        #region Handle Functions

        private void ApplayValidationsRules()
        {
            RuleFor(x => x.NameAr).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
        .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.NameEn).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
        }
        private void ApplayCustomValidationsRules()
        {
            RuleFor(x => x.Id).MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentIdExist(Key)).WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
            RuleFor(x => x.NameAr).MustAsync(async (model, key, CancellationToken) => !await _departmentService.IsNameArExistExcludeSelf(key, model.Id)).WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn).MustAsync(async (model, key, CancellationToken) => !await _departmentService.IsNameEnExistExcludeSelf(key, model.Id)).WithMessage(_localizer[SharedResourcesKeys.IsExist]);


            RuleFor(x => x.ManagerId)
                .MustAsync(async (managerId, cancellationToken) =>
                {
                    if (!managerId.HasValue)
                        return true;

                    return await _instructorService.IsInstructorIdExist(managerId.Value);
                }).WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
        }
        #endregion
    }
}
