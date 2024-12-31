using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.infrastructure.Data.Configurations
{
    public class Ins_SubjectConfiguration : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> builder)
        {
            builder.HasKey(x => new { x.SubID, x.InsId });
            builder.HasOne(x => x.Instructor).WithMany(x => x.Ins_Subjects).HasForeignKey(x => x.InsId);
            builder.HasOne(x => x.Subject).WithMany(x => x.Ins_Subjects).HasForeignKey(x => x.SubID);
        }
    }
}
