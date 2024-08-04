using Dapper;
using REALESTATE_DAPPER_API.Dtos.BottomGridDtos;
using REALESTATE_DAPPER_API.Dtos.PopularLocationDtos;
using REALESTATE_DAPPER_API.Dtos.ServiceDtos;
using REALESTATE_DAPPER_API.Models.dappercontext;
using REALESTATE_DAPPER_API.Repositories.BottomGridRepositories;

namespace REALESTATE_DAPPER_API.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Models.dappercontext.Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

		public  async Task CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
		{
			string query = "insert into PopularLocation (CityName,ImageUrl)values (@cityName,@ımageUrl)";
			var parameters = new DynamicParameters();
			parameters.Add("@cityName", createPopularLocationDto.CityName);
			parameters.Add("@ımageUrl", createPopularLocationDto.ImageUrl);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task DeletePopularLocation(int id)
		{
			string query = "Delete From PopularLocation Where LocationID=@locationID";
			var parameters = new DynamicParameters();
			parameters.Add("@locationID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultPopularLocationDtos>> GetAllPopularLocation()
        {
            string query = "select *from PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDtos>(query);
                return values.ToList();
            }

        }

		public async Task<GetByIdPopularLocationDto> GetPopularLocation(int id)
		{

			string query = "select*from PopularLocation where LocationID=@locationID";
			var parameters = new DynamicParameters();
			parameters.Add("@locationID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, parameters);
				return values;
			}
		}

		public async Task UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
		{

			string query = "update PopularLocation set CityName=@cityName,ImageUrl=@ımageUrl where LocationID=@locationID ";
			var parameters = new DynamicParameters();

			parameters.Add("@cityName", updatePopularLocationDto.CityName);
			parameters.Add("@ımageUrl", updatePopularLocationDto.ImageUrl);
			parameters.Add("@locationID", updatePopularLocationDto.LocationID);

			using (var connection = _context.CreateConnection())

			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
