namespace EmployeeService.Dtos
{
    public class PositionEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double SurplusFactor { get; set; }
    }
}
