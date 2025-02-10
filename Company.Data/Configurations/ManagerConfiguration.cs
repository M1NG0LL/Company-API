using Company.Model.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(200);

            builder.Property(e => e.Department)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.IsStillWorking).HasDefaultValue(true);


            builder.HasData(
                new Manager
                {
                    Id = Guid.Parse("ccedbb56-8ce2-42bd-9c1f-26db859c000d"),
                    Name = "John Doe",
                    Email = "john.doe@company.com",
                    Salary = 120000,
                    WorkStartDate = new DateTime(2015, 6, 1),
                    IsStillWorking = true,
                    Department = "IT"
                },
                new Manager
                {
                    Id = Guid.Parse("22b17cb6-2f32-49b0-9a14-8b343344a3f2"),
                    Name = "Jane Smith",
                    Email = "jane.smith@company.com",
                    Salary = 110000,
                    WorkStartDate = new DateTime(2017, 3, 15),
                    IsStillWorking = true,
                    Department = "HR"
                }
            );
        }
    }
}
