namespace EmployeeService.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }

        public Employee Employee { get; set; } = null!;
    }
}
