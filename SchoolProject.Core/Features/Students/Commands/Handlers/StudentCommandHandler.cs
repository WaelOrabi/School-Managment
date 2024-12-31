using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>, IRequestHandler<EditStudentCommand, Response<string>>, IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion
        #region Constructors
        public StudentCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(studentMapper);
            if (result == "Success")
                return GenerateCreatedResponse<string>("");
            else return GenerateBadRequestResponse<string>();

        }



        async Task<Response<string>> IRequestHandler<EditStudentCommand, Response<string>>.Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
                return GenerateNotFoundResponse<string>("Student is not found");

            var studentmapper = _mapper.Map(request, student);
            var result = await _studentService.EditAsync(studentmapper);
            if (result == "Success") return GenerateSuccessResponse<string>($"Edit Successfully {studentmapper.StudID}");
            else return GenerateBadRequestResponse<string>();
        }
        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
                return GenerateNotFoundResponse<string>("Student is not found");
            var result = await _studentService.DeleteAsync(student);
            if (result == "Success") return GenerateDeletedResponse<string>($"Deleted Successfulld {request.Id}");
            else return GenerateBadRequestResponse<string>();
        }
        #endregion
    }
}
