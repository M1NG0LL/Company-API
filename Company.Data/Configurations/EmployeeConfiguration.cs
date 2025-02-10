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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(200);

            builder.Property(e => e.Position)
                    .HasMaxLength(50);

            builder.Property(s => s.IsStillWorking).HasDefaultValue(true);

            builder.HasOne(e => e.Manager)
                   .WithMany(m => m.Workers)
                   .HasForeignKey(e => e.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasData(
                new Employee
                {
                    Id = Guid.Parse("6edca059-ab3e-4eea-9f32-0e36fd6533ed"),
                    Name = "Alice Johnson",
                    Email = "alice.johnson@company.com",
                    Salary = 70000,
                    WorkStartDate = new DateTime(2025, 2, 10),
                    IsStillWorking = true,
                    Position = "Software Engineer",
                    ManagerId = Guid.Parse("ccedbb56-8ce2-42bd-9c1f-26db859c000d")
                },
                new Employee
                {
                    Id = Guid.Parse("e7c392bd-2927-4f73-b6f0-66e40e48a674"),
                    Name = "Bob Williams",
                    Email = "bob.williams@company.com",
                    Salary = 75000,
                    WorkStartDate = new DateTime(2025, 2, 10),
                    IsStillWorking = true,
                    Position = "DevOps Engineer",
                    ManagerId = Guid.Parse("ccedbb56-8ce2-42bd-9c1f-26db859c000d")
                },
                new Employee
                {
                    Id = Guid.Parse("fa1ec6ae-3108-4d23-bd09-eac2bfdbfdb4"),
                    Name = "Charlie Brown",
                    Email = "charlie.brown@company.com",
                    Salary = 65000,
                    WorkStartDate = new DateTime(2025, 2, 10),
                    IsStillWorking = true,
                    Position = "HR Coordinator",
                    ManagerId = Guid.Parse("22b17cb6-2f32-49b0-9a14-8b343344a3f2")
                }
            );
        }
    }
}
