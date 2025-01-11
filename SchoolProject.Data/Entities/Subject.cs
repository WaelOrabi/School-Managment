using SchoolProject.Data.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entities
{
    public class Subject : GeneralLocalizableEntity
    {
        public Subject()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmetsSubjects = new HashSet<DepartmentSubject>();
            Ins_Subjects = new HashSet<InstructorSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubID { get; set; }
        [StringLength(100)]
        public string? SubjectNameAr { get; set; }
        [StringLength(100)]
        public string? SubjectNameEn { get; set; }
        public int? Period { get; set; }

        [InverseProperty(nameof(StudentSubject.Subject))]
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }

        [InverseProperty(nameof(DepartmentSubject.Subject))]
        public virtual ICollection<DepartmentSubject> DepartmetsSubjects { get; set; }

        [InverseProperty(nameof(InstructorSubject.Subject))]
        public virtual ICollection<InstructorSubject> Ins_Subjects { get; set; }
    }

}
