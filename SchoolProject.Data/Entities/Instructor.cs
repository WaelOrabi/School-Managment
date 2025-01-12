using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Instructor : GeneralLocalizableEntity
    {
        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            Ins_Subjects = new HashSet<InstructorSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsId { get; set; }
        [StringLength(100)]
        public string ENameAr { get; set; }
        [StringLength(100)]
        public string ENameEn { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(30)]
        public string Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal Salary { get; set; }
        public int? DID { get; set; }

        [ForeignKey(nameof(DID))]
        [InverseProperty(nameof(Department.Instructors))]
        public Department? department { get; set; }


        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty(nameof(Instructor.Instructors))]
        public Instructor? Supervisor { get; set; }


        [InverseProperty(nameof(Department.InstructorManager))]
        public Department? departmentManager { get; set; }


        [InverseProperty(nameof(Instructor.Supervisor))]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [InverseProperty(nameof(InstructorSubject.Instructor))]
        public virtual ICollection<InstructorSubject> Ins_Subjects { get; set; }
    }
}
