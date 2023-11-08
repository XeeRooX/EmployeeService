namespace EmployeeService.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double SurplusFactor { get; set; }

        public List<Employee> Employees { get; set; } = new();
    }
}
