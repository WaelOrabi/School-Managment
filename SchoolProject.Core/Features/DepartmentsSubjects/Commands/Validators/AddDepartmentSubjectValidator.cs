using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.DepartmentsSubjects.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.DepartmentsSubjects.Commands.Validators
{
    public class AddDepartmentSubjectValidator : AbstractValidator<AddDepartmentSubjectCommandModel>
    {
        #region Fields
        private readonly IDepartmentService _departmentService;
        private readonly ISubjectService _subjectService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion

        public AddDepartmentSubjectValidator(IDepartmentService departmentService, IStringLocalizer<SharedResources> localizer, ISubjectService subjectService)
        {
            _departmentService = departmentService;
            _localizer = localizer;

            _subjectService = subjectService;
            ApplayValidationsRules();
            ApplayCustomValidationsRules();

        }


        #region Actions
        public void ApplayValidationsRules()
        {
            RuleFor(x => x.DepartmentID).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.SubjectID).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);




        }
        public void ApplayCustomValidationsRules()
        {
            RuleFor(x => x.DepartmentID).MustAsync(async (key, CancellationToken) => await _departmentService.IsIdExist(key)).WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
            RuleFor(x => x.SubjectID).MustAsync(async (key, CancellationToken) => await _subjectService.IsIdExist(key)).WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);



        }
        #endregion
    }
}
