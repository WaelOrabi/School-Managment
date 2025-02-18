﻿using MediatR;

namespace SchoolProject.Core.Features.Instructors.Commands.Models
{
    public class AddInstructorCommandModel : IRequest<Response<string>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal Salary { get; set; }
        public int? DepartmentId { get; set; }
    }
}
