using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Departments.Queries.Responses;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Departments.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler, IRequestHandler<GetDepartmentByIdQueryModel, Response<GetDepartmentByIdQueryResponse>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        #endregion
        #region Constructors
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IDepartmentService departmentService, IMapper mapper, IStudentService studentService) : base(stringLocalizer)
        {
            _departmentService = departmentService;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            _studentService = studentService;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<GetDepartmentByIdQueryResponse>> Handle(GetDepartmentByIdQueryModel request, CancellationToken cancellationToken)
        {
            var response = await _departmentService.GetDepartmentById(request.Id);
            if (response == null) return GenerateNotFoundResponse<GetDepartmentByIdQueryResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var mapper = _mapper.Map<GetDepartmentByIdQueryResponse>(response);

            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.Localize(e.NameAr, e.NameEn));
            var studentQuerable = _studentService.GetStudentsByDepartmentIdQuerable(request.Id);
            var paginatedList = await studentQuerable.Select(expression).ToPaginatedListAsunc(request.StudentPageNumber, request.StudentPageSize);
            mapper.StudentList = paginatedList;
            return GenerateSuccessResponse<GetDepartmentByIdQueryResponse>(mapper);
        }
        #endregion
    }
}
