namespace EmployeeService.Dtos
{
    public class EmployeeAddDto
    {
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
