using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Departments.Commands.Validations
{
    public class DeleteDepartmentCommandValidator : AbstractValidator<EditDepartmentCommandModel>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentService _departmentService;

        #endregion
        #region Constructor
        public DeleteDepartmentCommandValidator(IStringLocalizer<SharedResources> localizer, IDepartmentService departmentService)
        {
            _localizer = localizer;
            _departmentService = departmentService;
            ApplayValidationsRules();
            ApplayCustomValidationsRules();
        }



        #endregion
        #region Handle Functions

        private void ApplayValidationsRules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
        .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);

        }
        private void ApplayCustomValidationsRules()
        {

        }
        #endregion
    }
}
