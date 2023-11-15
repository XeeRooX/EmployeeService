namespace EmployeeService.Dtos
{
    public class EmployeeFilterResultDto
    {
        public List<EmployeeDto> Items { get; set; } = new();
        public int CountPages { get; set; }
    }
}
