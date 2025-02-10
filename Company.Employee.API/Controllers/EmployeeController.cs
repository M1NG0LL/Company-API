using AutoMapper;
using ClosedXML.Excel;
using Company.Employee.API.Model.DTOs.Employee;
using Company.Employee.API.Repositories;
using Company.Employee.API.Repositories.REmployee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Company.Model.Domain.Employee, EmployeeDto, CreateEmployeeDto, UpdateEmployeeDto>
    {
        private readonly IRepository<Company.Model.Domain.Employee> repository;
        private readonly IMapper mapper;

        public EmployeeController(IRepository<Company.Model.Domain.Employee> repository, IMapper mapper)
            : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportToExcel()
        {
            var entities = await repository.GetAllAsync();
            var data = mapper.Map<List<EmployeeDto>>(entities);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Employees");

                // Headers
                worksheet.Cell(1, 1).Value = "Name";
                worksheet.Cell(1, 2).Value = "Email";
                worksheet.Cell(1, 3).Value = "Position";
                worksheet.Cell(1, 4).Value = "Salary";
                worksheet.Cell(1, 5).Value = "Is Still Working";
                worksheet.Cell(1, 6).Value = "Manager Name";

                // Seeding Data
                for (int row = 0; row < data.Count; row++)
                {
                    var employee = data[row];
                    worksheet.Cell(row + 2, 1).Value = employee.Name;
                    worksheet.Cell(row + 2, 2).Value = employee.Email;
                    worksheet.Cell(row + 2, 3).Value = employee.Position;
                    worksheet.Cell(row + 2, 4).Value = employee.Salary?.ToString() ?? "N/A";
                    worksheet.Cell(row + 2, 5).Value = employee.IsStillWorking?.ToString() ?? "N/A";
                    worksheet.Cell(row + 2, 6).Value = employee.Manager?.Name ?? "No Manager";
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employees.xlsx");
                }
            }
        }
    }
}
