using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Response;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>, IRequestHandler<GetStudentByIdQuery, Response<GetStudentResponse>>, IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        #region Fields
        private IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            var result = GenerateSuccessResponse(studentListMapper);
            result.Meta = new { Count = studentListMapper.Count() };
            return result;
        }

        public async Task<Response<GetStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdWithIncludeAsync(request.Id);
            var result = _mapper.Map<GetStudentResponse>(student);
            if (result == null)
                return GenerateNotFoundResponse<GetStudentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            return GenerateSuccessResponse<GetStudentResponse>(result);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            //var querable = _studentService.GetStudentsQuerable();
            var filter = _studentService.FilterStudentPaginatedQuerable(request.OrderBy, request.Search);
            //first way
            // Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Department.Localize(e.Department.DNameAr, e.Department.DNameEn));

            // var paginatedList = await filter.Select(expression).ToPaginatedListAsunc(request.PageNumber, request.PageSize);
            //second way
            //  var paginatedList = await filter.Select(x => new GetStudentPaginatedListResponse(x.StudID, x.Localize(x.NameAr, x.NameEn), x.Address, x.Department.Localize(x.Department.DNameAr, x.Department.DNameEn))).ToPaginatedListAsunc(request.PageNumber, request.PageSize);

            //three way
            var paginatedList = await _mapper.ProjectTo<GetStudentPaginatedListResponse>(filter).ToPaginatedListAsunc(request.PageNumber, request.PageSize);

            paginatedList.Meta = new { Count = paginatedList.Data.Count() };
            return paginatedList;
        }
        #endregion

    }
}
