using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Subjects.Commands.Handlers
{
    public class SubjectCommandHandler : ResponseHandler, IRequestHandler<AddSubjectCommandModel, Response<string>>,
                                                          IRequestHandler<EditSubjectCommandModel, Response<string>>,
                                                          IRequestHandler<DeleteSubjectCommandModel, Response<string>>

    {
        private readonly ISubjectService _subjectService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IMapper _mapper;
        public SubjectCommandHandler(IStringLocalizer<SharedResources> localizer, ISubjectService subjectService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _subjectService = subjectService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddSubjectCommandModel request, CancellationToken cancellationToken)
        {
            var subject = _mapper.Map<Subject>(request);
            var result = await _subjectService.AddSubject(subject);
            if (result == "Success")
                return GenerateCreatedResponse<string>("");
            else return GenerateBadRequestResponse<string>();
        }

        public async Task<Response<string>> Handle(EditSubjectCommandModel request, CancellationToken cancellationToken)
        {
            var subject = _mapper.Map<Subject>(request);
            var result = await _subjectService.EditSubject(subject);
            if (result == "Success")
                return GenerateCreatedResponse<string>("");
            else return GenerateBadRequestResponse<string>();
        }

        public async Task<Response<string>> Handle(DeleteSubjectCommandModel request, CancellationToken cancellationToken)
        {
            var department = await _subjectService.GetSubjectById(request.Id);
            if (department == null)
                return GenerateNotFoundResponse<string>();
            var result = await _subjectService.DeleteSubject(department);
            if (result == "Success") return GenerateDeletedResponse<string>();
            else return GenerateBadRequestResponse<string>();
        }
    }
}
