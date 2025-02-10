namespace Company.Employee.API.Model.DTOs.Manager
{
    public class UpdateManagerDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? WorkEndDate { get; set; }
        public bool? IsStillWorking { get; set; }
        public string Department { get; set; }
    }
}
