namespace Company.Employee.API.Model.DTOs.Employee
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? Salary { get; set; }
        public DateTime WorkStartDate { get; set; }
        public bool? IsStillWorking { get; set; }
        public string? Position { get; set; }
        public Guid? ManagerId { get; set; }
    }
}
