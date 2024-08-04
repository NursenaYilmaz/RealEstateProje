using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALESTATE_DAPPER_API.Dtos.ServiceDtos;
using REALESTATE_DAPPER_API.Repositories.ServiceRepository;

namespace REALESTATE_DAPPER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetServiceList() 
        {
            var value =  await _serviceRepository.GetAllService();
            return Ok(value);
        }
		[HttpPost]
		public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
		{
			await _serviceRepository.CreateService(createServiceDto);
			return Ok("hizmet kısmı başarılı şekilde eklendi");
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteService(int id)
		{
			await _serviceRepository.DeleteService(id);
			return Ok("hizmet kısmı başarılı şekilde silindi");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
		{
			await _serviceRepository.UpdateService(updateServiceDto);
			return Ok("hizmet kısmı başarılı şekilde güncellendi");

		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetService(int id)
		{
			var value = await _serviceRepository.GetService(id);
			return Ok(value);
		}
	}
}
