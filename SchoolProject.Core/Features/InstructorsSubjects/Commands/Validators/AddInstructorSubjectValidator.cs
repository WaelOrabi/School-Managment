using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.InstructorsSubjects.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.InstructorsSubjects.Commands.Validators
{
    public class AddInstructorSubjectValidator : AbstractValidator<AddInstructorSubjectCommandModel>
    {
        #region Fields
        private readonly IInstructorService _instructorService;
        private readonly ISubjectService _subjectService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        #endregion

        public AddInstructorSubjectValidator(IInstructorService instructorService, IStringLocalizer<SharedResources> localizer, ISubjectService subjectService)
        {
            _instructorService = instructorService;
            _localizer = localizer;

            _subjectService = subjectService;
            ApplayValidationsRules();
            ApplayCustomValidationsRules();

        }


        #region Actions
        public void ApplayValidationsRules()
        {
            RuleFor(x => x.InstructorId).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.SubjectId).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);




        }
        public void ApplayCustomValidationsRules()
        {
            RuleFor(x => x.InstructorId).MustAsync(async (key, CancellationToken) => await _instructorService.IsIdExist(key)).WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
            RuleFor(x => x.SubjectId).MustAsync(async (key, CancellationToken) => await _subjectService.IsIdExist(key)).WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);



        }
        #endregion
    }
}
