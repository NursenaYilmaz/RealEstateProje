using Dapper;
using REALESTATE_DAPPER_API.Dtos.CategoryDtos;
using REALESTATE_DAPPER_API.Dtos.EmployeeDtos;
using REALESTATE_DAPPER_API.Models.dappercontext;

namespace REALESTATE_DAPPER_API.Repositories.EmployeeRepositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly Models.dappercontext.Context _context;

		public EmployeeRepository(Context context)
		{
			_context = context;
		}
		public async Task CreateEmployee(CreateEmployeeDto createEmployeeDto)
		{
			string query = "insert into Employee (EmployeeName,EmployeeTitle,Mail,PhoneNumber,ImageUrl,Status)values (@name,@title,@mail,@phonenumber,@imageUrl,@status)";
			var parameters = new DynamicParameters();
			parameters.Add("@name", createEmployeeDto.EmployeeName);
			parameters.Add("@title", createEmployeeDto.EmployeeTitle);
			parameters.Add("@mail", createEmployeeDto.Mail);
			parameters.Add("@phonenumber", createEmployeeDto.PhoneNumber);
			parameters.Add("@imageUrl", createEmployeeDto.ImageUrl);
			parameters.Add("@status", true);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public  async Task DeleteEmployee(int id)
		{
			string query = "Delete From Employee Where EmployeeID=@EmployeeID";
			var parameters = new DynamicParameters();
			parameters.Add("@EmployeeID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultEmployeeDto>> GetAllEmployee()
		{
			string query = "select *from Employee";
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultEmployeeDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIdEmployeeDto> GetEmployee(int id)
		{

			string query = "select*from Employee where EmployeeID=@EmployeeID";
			var parameters = new DynamicParameters();
			parameters.Add("@EmployeeID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, parameters);
				return values;
			}
		}

		public  async Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
		{
			string query = "Update Employee Set EmployeeName=@name,EmployeeTitle=@title,Mail=@mail,PhoneNumber=@phonenumber,ImageUrl=@ımageUrl,Status=@status where EmployeeID=@EmployeeID";
			var parameters = new DynamicParameters();
			parameters.Add("@name", updateEmployeeDto.EmployeeName);
			parameters.Add("@title", updateEmployeeDto.EmployeeTitle);
			parameters.Add("@mail", updateEmployeeDto.Mail);
			parameters.Add("@phonenumber", updateEmployeeDto.PhoneNumber);
			parameters.Add("@ımageUrl", updateEmployeeDto.ImageUrl);
			parameters.Add("@status", updateEmployeeDto.Status);
			parameters.Add("@EmployeeID", updateEmployeeDto.EmployeeID);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
