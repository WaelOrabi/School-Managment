using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.InstructorsSubjects.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.InstructorsSubjects.Commands.Handlers
{
    public class InstructorSubjectCommandHandler : ResponseHandler, IRequestHandler<AddInstructorSubjectCommandModel, Response<string>>,
                                                                    IRequestHandler<DeleteInstructorSubjectCommandModel, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IInstructorSubjectService _instructorSubjectService;
        private readonly IMapper _mapper;
        public InstructorSubjectCommandHandler(IStringLocalizer<SharedResources> localizer, IInstructorSubjectService instructorSubjectService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _instructorSubjectService = instructorSubjectService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddInstructorSubjectCommandModel request, CancellationToken cancellationToken)
        {
            var instructorSubjectMapping = _mapper.Map<InstructorSubject>(request);
            var result = await _instructorSubjectService.AddInstructorSubject(instructorSubjectMapping);
            if (result == "Success")
                return GenerateCreatedResponse<string>("");
            else return GenerateBadRequestResponse<string>();
        }

        public async Task<Response<string>> Handle(DeleteInstructorSubjectCommandModel request, CancellationToken cancellationToken)
        {
            var result = await _instructorSubjectService.DeleteInstructorSubject(request.InstructorId, request.SubjectId);
            if (result == "Success") return GenerateDeletedResponse<string>("");
            else return GenerateNotFoundResponse<string>();
        }
    }
}
