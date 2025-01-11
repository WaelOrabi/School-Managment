using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.DepartmentsSubjects.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.DepartmentsSubjects.Commands.Handlers
{
    public class DepartmentSubjectCommandHandler : ResponseHandler, IRequestHandler<AddDepartmentSubjectCommandModel, Response<string>>,
                                                                    IRequestHandler<DeleteDepartmentSubjectCommandModel, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentSubjectService _departmentSubjectService;
        private readonly IMapper _mapper;
        public DepartmentSubjectCommandHandler(IStringLocalizer<SharedResources> localizer, IDepartmentSubjectService departmentSubjectService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _departmentSubjectService = departmentSubjectService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddDepartmentSubjectCommandModel request, CancellationToken cancellationToken)
        {
            var departmentSubject = _mapper.Map<DepartmentSubject>(request);
            var result = await _departmentSubjectService.AddDepartmentSubject(departmentSubject);
            if (result == "Success")
                return GenerateCreatedResponse<string>("");
            else return GenerateBadRequestResponse<string>();
        }

        public async Task<Response<string>> Handle(DeleteDepartmentSubjectCommandModel request, CancellationToken cancellationToken)
        {
            var result = await _departmentSubjectService.DeleteDepartmentSubject(request.DepartmentId, request.SubjectId);
            if (result == "Success") return GenerateDeletedResponse<string>("");
            else return GenerateNotFoundResponse<string>();
        }
    }
}
