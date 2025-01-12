using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Subjects.Queries.Models;
using SchoolProject.Core.Features.Subjects.Queries.Responses;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Subjects.Queries.Handlers
{
    public class SubjectQueryHandler : ResponseHandler, IRequestHandler<GetSubjectByIdQueryModel, Response<GetSubjectByIdQueryResponse>>,
                                                        IRequestHandler<GetSubjectListQueryModel, Response<List<GetSubjectListQueryResponse>>>,
                                                        IRequestHandler<GetSubjectPaginatedListQueryModel, PaginatedResult<GetSubjectPaginatedListQueryResponse>>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly ISubjectService _subjectService;
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public SubjectQueryHandler(IStringLocalizer<SharedResources> localizer, ISubjectService subjectService, IMapper mapper, IStudentService studentService) : base(localizer)
        {
            _localizer = localizer;
            _subjectService = subjectService;
            _mapper = mapper;
            _studentService = studentService;
        }

        public async Task<Response<GetSubjectByIdQueryResponse>> Handle(GetSubjectByIdQueryModel request, CancellationToken cancellationToken)
        {
            var response = await _subjectService.GetSubjectById(request.Id);
            if (response == null) return GenerateNotFoundResponse<GetSubjectByIdQueryResponse>(_localizer[SharedResourcesKeys.NotFound]);
            var mapper = _mapper.Map<GetSubjectByIdQueryResponse>(response);
            var studentsSubject = _studentService.GetStudentsBySubjectIdQuerable(request.Id);
            var paginatedList = await _mapper.ProjectTo<StudentSubjectResponse>(studentsSubject).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mapper.StudentsSubject = paginatedList;
            return GenerateSuccessResponse<GetSubjectByIdQueryResponse>(mapper);
        }

        public async Task<Response<List<GetSubjectListQueryResponse>>> Handle(GetSubjectListQueryModel request, CancellationToken cancellationToken)
        {
            var subjectList = await _subjectService.GetSubjectListAsync();
            var subjectListMapping = _mapper.Map<List<GetSubjectListQueryResponse>>(subjectList);
            var result = GenerateSuccessResponse(subjectListMapping);
            result.Meta = new { Count = subjectListMapping.Count() };
            return result;
        }

        public async Task<PaginatedResult<GetSubjectPaginatedListQueryResponse>> Handle(GetSubjectPaginatedListQueryModel request, CancellationToken cancellationToken)
        {
            var filter = _subjectService.FilterSubjectPaginatedQuerable(request.OrderBy, request.Search);
            var paginatedList = await _mapper.ProjectTo<GetSubjectPaginatedListQueryResponse>(filter).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            paginatedList.Meta = new { Count = paginatedList.Data.Count() };
            return paginatedList;
        }
    }
}
