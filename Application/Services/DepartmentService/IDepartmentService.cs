namespace Application.Services.DepartmentService
{
	public interface IDepartmentService
	{
		Task<bool> DepartmentValidationById(int id);
		Task<bool> DepartmentValidationByName(string name);
	}
}
