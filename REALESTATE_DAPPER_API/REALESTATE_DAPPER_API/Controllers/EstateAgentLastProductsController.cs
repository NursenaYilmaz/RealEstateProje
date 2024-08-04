using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALESTATE_DAPPER_API.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;

namespace REALESTATE_DAPPER_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EstateAgentLastProductsController : ControllerBase
	{
		private readonly ILastProductsRepository _lastProductsRepository;

		public EstateAgentLastProductsController(ILastProductsRepository lastProductsRepository)
		{
			_lastProductsRepository = lastProductsRepository;
		}
		[HttpGet]
		public async Task< IActionResult> GetLastProductsAsync(int id)
		{
			var values= await _lastProductsRepository.GetLast5ProductAsync(id);
			return Ok(values);
		}
	}
}
