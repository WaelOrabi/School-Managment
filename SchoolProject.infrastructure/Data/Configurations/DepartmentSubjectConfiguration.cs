using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.infrastructure.Data.Configurations
{
    public class DepartmentSubjectConfiguration : IEntityTypeConfiguration<DepartmentSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
        {
            builder.HasKey(x => new { x.SubID, x.DID });
            builder.HasOne(ds => ds.Department).WithMany(d => d.DepartmetsSubjects).HasForeignKey(ds => ds.DID);
            builder.HasOne(ds => ds.Subject).WithMany(s => s.DepartmetsSubjects).HasForeignKey(ds => ds.SubID);
        }
    }
}
