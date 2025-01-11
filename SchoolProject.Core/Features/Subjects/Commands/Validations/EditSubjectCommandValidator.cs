using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Subjects.Commands.Validations
{
    public class EditSubjectCommandValidator : AbstractValidator<EditSubjectCommandModel>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly ISubjectService _subjectService;

        #endregion
        #region Constructor
        public EditSubjectCommandValidator(IStringLocalizer<SharedResources> localizer, ISubjectService subjectService)
        {
            _localizer = localizer;
            _subjectService = subjectService;
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
            RuleFor(x => x.Period).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
           .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
        }
        private void ApplayCustomValidationsRules()
        {
            RuleFor(x => x.NameAr).MustAsync(async (model, key, CancellationToken) => !await _subjectService.IsNameArExistExcludeSelf(key, model.Id)).WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn).MustAsync(async (model, key, CancellationToken) => !await _subjectService.IsNameEnExistExcludeSelf(key, model.Id)).WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.Id).MustAsync(async (Key, CancellationToken) => await _subjectService.IsSubjectIdExist(Key)).WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);

        }
        #endregion
    }
}
