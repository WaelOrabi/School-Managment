using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>, IRequestHandler<EditStudentCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = _mapper.Map<Student>(request);
            var result = await _studentService.AddAsync(studentMapper);
            //  if (result == "Exist") return GenerateUnprocessableEntityResponse<string>("Name is Exist");
            //    else if (result == "Success") return GenerateCreatedResponse<string>("Added Successfully");
            // else return GenerateBadRequestResponse<string>();
            if (result == "Success")
                return GenerateCreatedResponse<string>("Added Successfully");
            else return GenerateBadRequestResponse<string>();

        }



        async Task<Response<string>> IRequestHandler<EditStudentCommand, Response<string>>.Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.Id);
            if (student == null)
                return GenerateNotFoundResponse<string>("Student is not found");

            var studentmapper = _mapper.Map<Student>(request);
            var result = await _studentService.EditAsync(studentmapper);
            if (result == "Success") return GenerateSuccessResponse<string>($"Edit Successfully {studentmapper.StudID}");
            else return GenerateBadRequestResponse<string>();
        }
        #endregion
    }
}
