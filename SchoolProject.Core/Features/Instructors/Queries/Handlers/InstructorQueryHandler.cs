using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Queries.Models;
using SchoolProject.Core.Features.Instructors.Queries.Response;
using SchoolProject.Core.Features.Instructors.Queries.Responses;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Instructors.Queries.Handlers
{
    public class InstructorQueryHandler : ResponseHandler, IRequestHandler<GetInstructorByIdQueryModel, Response<GetInstructorByIdQueryResponse>>,
                                                           IRequestHandler<GetInstructorListQueryModel, Response<List<GetInstructorListQueryResponse>>>,
                                                           IRequestHandler<GetInstructorPaginatedListQueryModel, PaginatedResult<GetInstructorPaginatedListQueryResponse>>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;
        public InstructorQueryHandler(IStringLocalizer<SharedResources> localizer, IInstructorService instructorService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _instructorService = instructorService;
            _mapper = mapper;
        }

        public async Task<Response<GetInstructorByIdQueryResponse>> Handle(GetInstructorByIdQueryModel request, CancellationToken cancellationToken)
        {
            var instructor = await _instructorService.GetInstructorById(request.Id);
            if (instructor == null)
                return GenerateNotFoundResponse<GetInstructorByIdQueryResponse>(_localizer[SharedResourcesKeys.NotFound]);


            var result = _mapper.Map<GetInstructorByIdQueryResponse>(instructor);
            return GenerateSuccessResponse(result);
        }

        public async Task<Response<List<GetInstructorListQueryResponse>>> Handle(GetInstructorListQueryModel request, CancellationToken cancellationToken)
        {
            var instructors = await _instructorService.GetInstructorListAsync();
            var instructorsMapping = _mapper.Map<List<GetInstructorListQueryResponse>>(instructors);
            var result = GenerateSuccessResponse(instructorsMapping);
            result.Meta = new { Count = instructorsMapping.Count() };
            return result;
        }

        public async Task<PaginatedResult<GetInstructorPaginatedListQueryResponse>> Handle(GetInstructorPaginatedListQueryModel request, CancellationToken cancellationToken)
        {
            var instructorsFilter = _instructorService.FilterInstructorPaginatedQuerable(request.OrderBy, request.Search);
            var instructorsMapping = _mapper.ProjectTo<GetInstructorPaginatedListQueryResponse>(instructorsFilter);
            var paginatedList = await instructorsMapping.ToPaginatedListAsync(request.PageNumber, request.PageSize);

            paginatedList.Meta = new { Count = paginatedList.Data.Count() };
            return paginatedList;
        }
    }
}
