using Dapper;
using REALESTATE_DAPPER_API.Dtos.CategoryDtos;
using REALESTATE_DAPPER_API.Dtos.ServiceDtos;
using REALESTATE_DAPPER_API.Dtos.WhoWeAreDetailDtos;
using REALESTATE_DAPPER_API.Models.dappercontext;

namespace REALESTATE_DAPPER_API.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Models.dappercontext.Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateService(CreateServiceDto createServiceDto)
        {
			string query = "insert into Service (ServiceName,ServiceStatus)values (@serviceName,@serviceStatus)";
			var parameters = new DynamicParameters();
			parameters.Add("@serviceName", createServiceDto.ServiceName);
			parameters.Add("@serviceStatus", createServiceDto.ServiceStatus);
	
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

        public async Task DeleteService(int id)
        {
			string query = "Delete From Service Where ServiceID=@serviceID";
			var parameters = new DynamicParameters();
			parameters.Add("@serviceID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

        public async Task<List<ResultServiceDto>> GetAllService()
        {
            string query = "select *from Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public  async Task<GetByIdServiceDto> GetService(int id)
        {
			string query = "select*from Service where ServiceID=@serviceID";
			var parameters = new DynamicParameters();
			parameters.Add("@serviceID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query, parameters);
				return values;
			}
		}

        public  async Task UpdateService(UpdateServiceDto updateServiceDto)
        {
			string query = "update Service set ServiceName=@serviceName,ServiceStatus=@serviceStatus where ServiceID=@serviceID ";
			var parameters = new DynamicParameters();
			
			parameters.Add("@serviceName", updateServiceDto.ServiceName);
			parameters.Add("@serviceStatus", updateServiceDto.ServiceStatus);
			parameters.Add("@serviceID", updateServiceDto.ServiceID);

			using (var connection = _context.CreateConnection())

			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
    }
}
