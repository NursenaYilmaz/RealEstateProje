using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALESTATE_DAPPER_API.Repositories.ProductImageRepositories;

namespace REALESTATE_DAPPER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageRepository _productImageRepsoitory;
    public ProductImagesController(IProductImageRepository productImageRepsoitory)
        {
            _productImageRepsoitory = productImageRepsoitory;
        }
        [HttpGet]
        public async Task<IActionResult>GetProductImageById(int id)
        {
            var values=await _productImageRepsoitory.GetProductImageByProductId(id);
            return Ok(values);
        }
    }
}
