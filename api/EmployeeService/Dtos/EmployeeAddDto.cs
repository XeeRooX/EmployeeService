namespace EmployeeService.Dtos
{
    public class EmployeeAddDto
    {
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }

        public DateOnly DateOfEmployment { get; set; }
        public double TariffRate { get; set; }

    }
}
