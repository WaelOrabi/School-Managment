﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{

    public class StudentSubject
    {
        [Key]
        public int StudID { get; set; }
        [Key]
        public int SubID { get; set; }
        public decimal? Grade { get; set; }

        [ForeignKey("StudID")]
        [InverseProperty(nameof(Student.StudentsSubjects))]
        public virtual Student? Student { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty(nameof(Subject.StudentsSubjects))]
        public virtual Subject? Subject { get; set; }

    }
}
