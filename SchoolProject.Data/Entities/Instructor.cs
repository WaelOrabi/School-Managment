using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsId { get; set; }
        public string? ENameAr { get; set; }
        public string? ENameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }

        public int? DID { get; set; }
        [ForeignKey(nameof(DID))]
        [InverseProperty(nameof(Department.Instructors))]
        public Department? department { get; set; }
        [InverseProperty(nameof(Department.InstructorManager))]
        public Department? departmentManager { get; set; }

        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty(nameof(Instructor.Instructors))]
        public Instructor? Supervisor { get; set; }
        [InverseProperty(nameof(Instructor.Supervisor))]
        public virtual ICollection<Instructor> Instructors { get; set; }
        [InverseProperty(nameof(Ins_Subject.Instructor))]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
    }
}
