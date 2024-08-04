using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALESTATE_DAPPER_API.Dtos.BottomGridDtos;
using REALESTATE_DAPPER_API.Repositories.BottomGridRepositories;

namespace REALESTATE_DAPPER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;
    public BottomGridsController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetBottomGridList() {
            var values = await _bottomGridRepository.GetAllBottomGrid();
            return Ok(values);
        }
		[HttpPost]
		public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
		{
			await _bottomGridRepository.CreateBottomGrid(createBottomGridDto);
			return Ok("veri başarılı şekilde eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteBottomGrid(int id)
		{
			await _bottomGridRepository.DeleteBottomGrid(id);
			return Ok("veri başarılı şekilde silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
		{
			await _bottomGridRepository.UpdateBottomGrid(updateBottomGridDto);
			return Ok("veri başarılı şekilde güncellendi");

		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetBottomGrid(int id)
		{
			var value = await _bottomGridRepository.GetBottomGrid(id);
			return Ok(value);
		}
	}
}
