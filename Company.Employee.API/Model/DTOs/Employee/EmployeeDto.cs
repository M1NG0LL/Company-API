using Company.Employee.API.Model.DTOs.Manager;

namespace Company.Employee.API.Model.DTOs.Employee
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? Salary { get; set; }
        public DateTime WorkStartDate { get; set; }
        public DateTime? WorkEndDate { get; set; }
        public bool? IsStillWorking { get; set; }
        public string? Position { get; set; }
        public Guid? ManagerId { get; set; }
        public ManagerDto? Manager { get; set; }
    }
}
