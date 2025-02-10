namespace Company.Model.Domain
{
    public class Manager : BaseDomainModel
    {
        public string Department { get; set; }

        public List<Employee>? Workers { get; set; }
    }
}
