namespace EmployeeService.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public DateOnly DateOfEmployment { get; set; }
        public double TariffRate { get; set; }

        public Department Department { get; set; } = null!;
        public int DepartmentId { get; set; }
        public Position Position { get; set; } = null!;
        public int PositionId { get; set; }
        public Person Person { get; set; } = null!;
        public int PersonId { get; set; }
    }
}
