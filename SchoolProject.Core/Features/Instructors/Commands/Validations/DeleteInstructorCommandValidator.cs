using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Instructors.Commands.Validations
{
    public class DeleteInstructorCommandValidator : AbstractValidator<DeleteInstructorCommandModel>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _localizer;


        #endregion
        #region Constructor
        public DeleteInstructorCommandValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
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
