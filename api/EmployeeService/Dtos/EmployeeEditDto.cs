namespace EmployeeService.Dtos
{
    public class EmployeeEditDto
    {
        public int EmployeeId { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public double TariffRate { get; set; }
        public int PostionId { get; set; }
        public int DepartmentId { get; set; }
    }
}
