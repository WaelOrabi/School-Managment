using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public partial class Department : GeneralLocalizableEntity

    {
        public Department()
        {
            DepartmetsSubjects = new HashSet<DepartmentSubject>();
            Students = new HashSet<Student>();
            Instructors = new HashSet<Instructor>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }
        [StringLength(100)]
        public string DNameAr { get; set; }
        [StringLength(100)]
        public string DNameEn { get; set; }
        public int? InsManager { get; set; }

        [InverseProperty(nameof(Student.Department))]
        public virtual ICollection<Student> Students { get; set; }

        [InverseProperty(nameof(DepartmentSubject.Department))]
        public virtual ICollection<DepartmentSubject> DepartmetsSubjects { get; set; }

        [InverseProperty(nameof(Instructor.department))]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [ForeignKey(nameof(InsManager))]
        [InverseProperty(nameof(Instructor.departmentManager))]
        public virtual Instructor? InstructorManager { get; set; }
    }
}
