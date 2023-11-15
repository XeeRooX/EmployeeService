namespace EmployeeService.Dtos
{
    public class EmployeeFilterDto
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int PositionId { get; set; }
        public string SortBy { get; set; } = null!;
        public bool SortByDescending { get; set; }
    }
}
