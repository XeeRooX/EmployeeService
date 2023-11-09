namespace EmployeeService.Dtos
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double SurplusFactor { get; set; }
    }
}
