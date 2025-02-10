using Company.Employee.API.Model.DTOs.Employee;

namespace Company.Employee.API.Model.DTOs.Manager
{
    public class ManagerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? Salary { get; set; }
        public DateTime WorkStartDate { get; set; }
        public DateTime? WorkEndDate { get; set; }
        public bool? IsStillWorking { get; set; }
        public string Department { get; set; }
    }
}
