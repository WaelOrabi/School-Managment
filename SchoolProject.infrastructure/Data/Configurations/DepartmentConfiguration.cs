using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.infrastructure.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.DID);
            builder.Property(x => x.DNameAr).HasMaxLength(100);
            builder.HasOne(x => x.InstructorManager).WithOne(x => x.departmentManager).HasForeignKey<Department>(x => x.InsManager).OnDelete(DeleteBehavior.SetNull);
            builder.HasMany(x => x.Students).WithOne(x => x.Department).HasForeignKey(x => x.DID).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
