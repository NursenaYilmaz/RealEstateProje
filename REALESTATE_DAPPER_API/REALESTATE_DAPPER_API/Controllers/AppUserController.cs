using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALESTATE_DAPPER_API.Repositories.AppUserRepositories;

namespace REALESTATE_DAPPER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUserController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }
        [HttpGet]
        public async Task<IActionResult>GetAppUserByProductId(int id)
        {
            var values= await _appUserRepository.GetAppUserByProductId(id);
            return Ok(values);
        }
    }
}
