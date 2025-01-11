using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Departments.Commands.Handlers
{
    public class DepartmentCommandHandler : ResponseHandler, IRequestHandler<AddDepartmentCommandModel, Response<string>>,
                                                             IRequestHandler<EditDepartmentCommandModel, Response<string>>,
                                                             IRequestHandler<DeleteDepartmentCommandModel, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public DepartmentCommandHandler(IStringLocalizer<SharedResources> localizer, IDepartmentService departmentService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _departmentService = departmentService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddDepartmentCommandModel request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Department>(request);
            var result = await _departmentService.AddDepartment(department);
            if (result == "Success")
                return GenerateCreatedResponse<string>("");
            else return GenerateBadRequestResponse<string>();
        }

        public async Task<Response<string>> Handle(EditDepartmentCommandModel request, CancellationToken cancellationToken)
        {
            var department = _mapper.Map<Department>(request);
            var result = await _departmentService.EditDepartment(department);
            if (result == "Success") return GenerateSuccessResponse<string>("");
            else return GenerateBadRequestResponse<string>();
        }

        public async Task<Response<string>> Handle(DeleteDepartmentCommandModel request, CancellationToken cancellationToken)
        {
            var department = await _departmentService.GetDepartmentById(request.Id);
            if (department == null)
                return GenerateNotFoundResponse<string>();
            var result = await _departmentService.DeleteDepartment(department);
            if (result == "Success") return GenerateDeletedResponse<string>();
            else return GenerateBadRequestResponse<string>();
        }
    }
}
