﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.infrastructure.Data.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasOne(x => x.Supervisor).WithMany(x => x.Instructors).HasForeignKey(x => x.SupervisorId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
