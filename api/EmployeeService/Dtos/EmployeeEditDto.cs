namespace EmployeeService.Dtos
{
    public class EmployeeEditDto
    {
        public int EmployeeId { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }

        public DateOnly DateOfEmployment { get; set; }
        public double TariffRate { get; set; }
    }
}
