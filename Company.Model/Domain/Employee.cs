namespace Company.Model.Domain
{
    public class Employee : BaseDomainModel
    {
        public string? Position { get; set; }

        public Guid? ManagerId { get; set; }
        public virtual Manager? Manager { get; set; }
    }
}
