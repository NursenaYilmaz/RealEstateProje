using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALESTATE_DAPPER_API.Dtos.CategoryDtos;
using REALESTATE_DAPPER_API.Dtos.EmployeeDtos;
using REALESTATE_DAPPER_API.Repositories.CategoryRepository;
using REALESTATE_DAPPER_API.Repositories.EmployeeRepositories;

namespace REALESTATE_DAPPER_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;


		public EmployeesController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}
		[HttpGet]
		public async Task<IActionResult> EmployeeList()
		{
			var values = await _employeeRepository.GetAllEmployee();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
		{
			await _employeeRepository.CreateEmployee(createEmployeeDto);
			return Ok("personel başarılı şekilde eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteEmployee(int id)
		{
			await _employeeRepository.DeleteEmployee(id);
			return Ok("personel başarılı şekilde silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
		{
			await _employeeRepository.UpdateEmployee(updateEmployeeDto);
			return Ok("personel başarılı şekilde güncellendi");

		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetEmployee(int id)
		{
			var value = await _employeeRepository.GetEmployee(id);
			return Ok(value);
		}
	}
}
