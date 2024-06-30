namespace Application.Features.Departments.Commands.SoftDelete
{
    public class SoftDeleteDepartmentResponse
    {
        public int Id { get; set; }
        public string Detail { get; set; } = "Deletion Successful!";
    }
}
