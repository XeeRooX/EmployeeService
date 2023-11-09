namespace EmployeeService.Dtos
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public double Salary { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; } = null!;
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;

    }
}
