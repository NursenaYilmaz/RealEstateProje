using Dapper;
using REALESTATE_DAPPER_API.Dtos.ChartDtos;
using REALESTATE_DAPPER_API.Models.dappercontext;

namespace REALESTATE_DAPPER_API.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly Models.dappercontext.Context _context;

        public ChartRepository(Context context)
        {
            _context = context;
        }

        public  async Task<List<ResultChartDto>> Get5CityForChart()
        {
            string query = "select top(5) ProductCity,Count(*) as 'CityCount' From Product Group By ProductCity Order By CityCount Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultChartDto>(query);
                return values.ToList();
            }
        }
    }
}
