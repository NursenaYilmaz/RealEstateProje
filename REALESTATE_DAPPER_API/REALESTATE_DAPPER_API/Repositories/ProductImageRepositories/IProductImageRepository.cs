using REALESTATE_DAPPER_API.Dtos.ProductImageDtos;

namespace REALESTATE_DAPPER_API.Repositories.ProductImageRepositories
{
    public interface IProductImageRepository
    {
        Task<List<GetProductımageByProductIdDto>> GetProductImageByProductId(int id);
    }
}
