using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>, IRequestHandler<GetStudentByIdQuery, Response<GetStudentResponse>>, IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        #region Fields
        private IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return GenerateSuccessResponse(studentListMapper);
        }

        public async Task<Response<GetStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithIncludeAsync(request.Id);
            var result = _mapper.Map<GetStudentResponse>(student);
            if (result == null)
                return GenerateNotFoundResponse<GetStudentResponse>("object not found");
            return GenerateSuccessResponse<GetStudentResponse>(result);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Name, e.Address, e.Department.DName);
            //var querable = _studentService.GetStudentsQuerable();
            var filter = _studentService.FilterStudentPaginatedQuerable(request.OrderBy, request.Search);
            var paginatedList = await filter.Select(expression).ToPaginatedListAsunc(request.PageNumber, request.PageSize);
            return paginatedList;
        }
        #endregion

    }
}
