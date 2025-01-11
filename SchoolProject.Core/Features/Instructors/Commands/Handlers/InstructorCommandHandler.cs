using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Instructors.Commands.Handlers
{
    public class InstructorCommandHandler : ResponseHandler, IRequestHandler<AddInstructorCommandModel, Response<string>>,
                                                      IRequestHandler<EditInstructorCommandModel, Response<string>>,
                                                      IRequestHandler<DeleteInstructorCommandModel, Response<string>>

    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;
        public InstructorCommandHandler(IStringLocalizer<SharedResources> localizer, IInstructorService instructorService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _instructorService = instructorService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddInstructorCommandModel request, CancellationToken cancellationToken)
        {
            var instructorMapping = _mapper.Map<Instructor>(request);
            var result = await _instructorService.AddInstructor(instructorMapping);
            if (result == "Success")
                return GenerateSuccessResponse<string>("");
            return GenerateBadRequestResponse<string>();

        }

        public async Task<Response<string>> Handle(EditInstructorCommandModel request, CancellationToken cancellationToken)
        {

            var instructorMapping = _mapper.Map<Instructor>(request);
            var result = await _instructorService.EditInstructor(instructorMapping);
            if (result == "Success")
                return GenerateSuccessResponse<string>("");
            return GenerateBadRequestResponse<string>();
        }

        public async Task<Response<string>> Handle(DeleteInstructorCommandModel request, CancellationToken cancellationToken)
        {
            var instructor = await _instructorService.GetInstructorById(request.Id);
            if (instructor == null)
                return GenerateNotFoundResponse<string>();
            var result = await _instructorService.DeleteInstructor(instructor);
            if (result == "Success")
                return GenerateDeletedResponse<string>();
            return GenerateBadRequestResponse<string>();

        }
    }
}
