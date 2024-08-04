using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALESTATE_DAPPER_API.Dtos.PopularLocationDtos;
using REALESTATE_DAPPER_API.Repositories.PopularLocationRepositories;

namespace REALESTATE_DAPPER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _locationRepository;

        public PopularLocationsController(IPopularLocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        [HttpGet]
        public  async Task<IActionResult> PopularLocationList()
        {
            var value =await _locationRepository.GetAllPopularLocation();
            return Ok(value);
        }
		[HttpPost]
		public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
		{
			await _locationRepository.CreatePopularLocation(createPopularLocationDto);
			return Ok("lokasyon kısmı başarılı şekilde eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletePopularLocation(int id)
		{
			await _locationRepository.DeletePopularLocation(id);
			return Ok("lokasyon kısmı başarılı şekilde silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
		{
			await _locationRepository.UpdatePopularLocation(updatePopularLocationDto);
			return Ok("lokasyon kısmı başarılı şekilde güncellendi");

		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetPopularLocation(int id)
		{
			var value = await _locationRepository.GetPopularLocation(id);
			return Ok(value);
		}
	}
}
