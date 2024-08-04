using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALESTATE_DAPPER_API.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;

namespace REALESTATE_DAPPER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentChartController : ControllerBase
    {
        private readonly IChartRepository _chartRepository;

        public EstateAgentChartController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get5CityForChart()
        {
            return Ok(await _chartRepository.Get5CityForChart());
        }
    }
}
