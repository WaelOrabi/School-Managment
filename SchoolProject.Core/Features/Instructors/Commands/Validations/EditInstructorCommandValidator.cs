using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Instructors.Commands.Validations
{
    public class EditInstructorCommandValidator : AbstractValidator<EditInstructorCommandModel>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IInstructorService _instructorService;
        private readonly IDepartmentService _departmentService;

        #endregion
        #region Constructor
        public EditInstructorCommandValidator(IStringLocalizer<SharedResources> localizer, IInstructorService instructorService, IDepartmentService departmentService)
        {
            _localizer = localizer;
            _instructorService = instructorService;
            _departmentService = departmentService;
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
            RuleFor(x => x.Address).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.Position).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
           .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
        }
        private void ApplayCustomValidationsRules()
        {
            RuleFor(x => x.Id).MustAsync(async (key, CancellationToken) => await _instructorService.IsInstructorIdExist(key)).WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);

            RuleFor(x => x.NameAr).MustAsync(async (model, key, CancellationToken) => !await _instructorService.IsNameArExistExcludeSelf(key, model.Id)).WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn).MustAsync(async (model, key, CancellationToken) => !await _instructorService.IsNameEnExistExcludeSelf(key, model.Id)).WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.SupervisorId)
           .MustAsync(async (supervisorId, cancellationToken) =>
           {
               if (!supervisorId.HasValue)
                   return true;

               return await _instructorService.IsSupervisorExist(supervisorId.Value);
           }).WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
            RuleFor(x => x.DepartmentId)
           .MustAsync(async (departmentId, cancellationToken) =>
           {
               if (!departmentId.HasValue)
                   return true;

               return await _departmentService.IsDepartmentIdExist(departmentId.Value);
           }).WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
        }
        #endregion
    }
}
