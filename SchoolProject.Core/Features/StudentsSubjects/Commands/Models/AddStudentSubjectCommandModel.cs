using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.StudentsSubjects.Commands.Models
{
    public class AddStudentSubjectCommandModel:IRequest<Response<string>>
    {
        public int StudID { get; set; }
     
        public int SubID { get; set; }
        public decimal? Grade { get; set; }
    }
}
