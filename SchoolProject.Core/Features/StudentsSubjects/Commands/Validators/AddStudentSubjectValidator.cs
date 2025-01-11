using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.StudentsSubjects.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.StudentsSubjects.Commands.Validators
{
    public class AddStudentSubjectValidator:AbstractValidator<AddStudentSubjectCommandModel>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly IStringLocalizer<SharedResources> _localizer;
      
        #endregion

        public AddStudentSubjectValidator(IStudentService studentService, IStringLocalizer<SharedResources> localizer, ISubjectService subjectService)
        {
            _studentService = studentService;
            _localizer = localizer;
      
            _subjectService = subjectService;
            ApplayValidationsRules();
            ApplayCustomValidationsRules();
           
        }


        #region Actions
        public void ApplayValidationsRules()
        {
            RuleFor(x => x.StudID).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);
            RuleFor(x => x.SubID).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);

            RuleFor(x => x.Grade).NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
           .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull]);

 
        }
        public void ApplayCustomValidationsRules()
        {
            RuleFor(x => x.StudID).MustAsync(async (key, CancellationToken) => await _studentService.IsIdExist(key)).WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
            RuleFor(x => x.SubID).MustAsync(async (key, CancellationToken) => await _subjectService.IsIdExist(key)).WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);



        }
        #endregion
    }
}
