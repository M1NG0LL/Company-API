using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Company.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Department", "Email", "IsStillWorking", "Name", "Salary", "WorkEndDate", "WorkStartDate" },
                values: new object[,]
                {
                    { new Guid("22b17cb6-2f32-49b0-9a14-8b343344a3f2"), "HR", "jane.smith@company.com", true, "Jane Smith", 110000m, null, new DateTime(2017, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ccedbb56-8ce2-42bd-9c1f-26db859c000d"), "IT", "john.doe@company.com", true, "John Doe", 120000m, null, new DateTime(2015, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "IsStillWorking", "ManagerId", "Name", "Position", "Salary", "WorkEndDate", "WorkStartDate" },
                values: new object[,]
                {
                    { new Guid("6edca059-ab3e-4eea-9f32-0e36fd6533ed"), "alice.johnson@company.com", true, new Guid("ccedbb56-8ce2-42bd-9c1f-26db859c000d"), "Alice Johnson", "Software Engineer", 70000m, null, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7c392bd-2927-4f73-b6f0-66e40e48a674"), "bob.williams@company.com", true, new Guid("ccedbb56-8ce2-42bd-9c1f-26db859c000d"), "Bob Williams", "DevOps Engineer", 75000m, null, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa1ec6ae-3108-4d23-bd09-eac2bfdbfdb4"), "charlie.brown@company.com", true, new Guid("22b17cb6-2f32-49b0-9a14-8b343344a3f2"), "Charlie Brown", "HR Coordinator", 65000m, null, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("6edca059-ab3e-4eea-9f32-0e36fd6533ed"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("e7c392bd-2927-4f73-b6f0-66e40e48a674"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("fa1ec6ae-3108-4d23-bd09-eac2bfdbfdb4"));

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("22b17cb6-2f32-49b0-9a14-8b343344a3f2"));

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: new Guid("ccedbb56-8ce2-42bd-9c1f-26db859c000d"));
        }
    }
}
