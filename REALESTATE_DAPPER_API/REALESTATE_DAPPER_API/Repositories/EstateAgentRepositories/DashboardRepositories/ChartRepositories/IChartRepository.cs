using REALESTATE_DAPPER_API.Dtos.ChartDtos;

namespace REALESTATE_DAPPER_API.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public interface IChartRepository
    {
       Task<List<ResultChartDto>> Get5CityForChart();
    }
}
