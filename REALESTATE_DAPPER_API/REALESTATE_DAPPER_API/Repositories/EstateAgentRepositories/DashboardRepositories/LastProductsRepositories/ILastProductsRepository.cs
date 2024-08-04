using REALESTATE_DAPPER_API.Dtos.ProductDtos;

namespace REALESTATE_DAPPER_API.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
	public interface ILastProductsRepository
	{
		Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id);
	}
}
