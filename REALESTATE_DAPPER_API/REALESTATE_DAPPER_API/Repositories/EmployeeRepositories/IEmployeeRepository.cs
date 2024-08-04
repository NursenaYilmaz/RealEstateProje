using REALESTATE_DAPPER_API.Dtos.CategoryDtos;
using REALESTATE_DAPPER_API.Dtos.EmployeeDtos;

namespace REALESTATE_DAPPER_API.Repositories.EmployeeRepositories
{
	public interface IEmployeeRepository
	{
		Task<List<ResultEmployeeDto>> GetAllEmployee();
        Task CreateEmployee(CreateEmployeeDto createEmployeeDto);
        Task DeleteEmployee(int id);

        Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
		Task<GetByIdEmployeeDto> GetEmployee(int id);

	}
}
