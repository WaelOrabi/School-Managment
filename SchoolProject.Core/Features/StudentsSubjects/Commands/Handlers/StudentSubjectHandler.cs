using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.StudentsSubjects.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;


namespace SchoolProject.Core.Features.StudentsSubjects.Commands.Handlers
{
    public class StudentSubjectHandler : ResponseHandler, IRequestHandler<AddStudentSubjectCommandModel, Response<string>>,
                                                          IRequestHandler<EditStudentSubjectCommandModel, Response<string>>,
                                                          IRequestHandler<DeleteStudentSubjectCommandModel, Response<string>>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IStudentSubjectService _studentSubjectService;
        private readonly IMapper _mapper;
        public StudentSubjectHandler(IStringLocalizer<SharedResources> localizer, IStudentSubjectService studentSubjectService, IMapper mapper) : base(localizer)
        {
            _localizer = localizer;
            _studentSubjectService = studentSubjectService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddStudentSubjectCommandModel request, CancellationToken cancellationToken)
        {
            var studentSubject = _mapper.Map<StudentSubject>(request);
            var result = await _studentSubjectService.AddStudentSubject(studentSubject);
            if (result == "Success")
                return GenerateCreatedResponse<string>("");
            else return GenerateBadRequestResponse<string>();
        }

        public async Task<Response<string>> Handle(EditStudentSubjectCommandModel request, CancellationToken cancellationToken)
        {
            var studentSubject = _mapper.Map<StudentSubject>(request);
            var result = await _studentSubjectService.EditStudentSubject(studentSubject);
            if (result == "Success") return GenerateSuccessResponse<string>("");
            else return GenerateNotFoundResponse<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentSubjectCommandModel request, CancellationToken cancellationToken)
        {

            var result = await _studentSubjectService.DeleteStudentSubject(request.StudentId, request.SubjectId);
            if (result == "Success") return GenerateDeletedResponse<string>("");
            else return GenerateNotFoundResponse<string>();
        }
    }
}
