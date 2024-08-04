using Dapper;
using REALESTATE_DAPPER_API.Dtos.ProductDtos;
using REALESTATE_DAPPER_API.Models.dappercontext;

namespace REALESTATE_DAPPER_API.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
	public class LastProductsRepository : ILastProductsRepository
	{
		private readonly Models.dappercontext.Context _context;

		public LastProductsRepository(Context context)
		{
			_context = context;
		}
		public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync(int id)
		{
			string query = "select top(5) ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,ProductCategory,CategoryName,AdvertisementDay,AppUserID from Product Inner Join Category on Product.ProductCategory=Category.CategoryID where AppUserID=@appUserID order by ProductID Desc";
			var parameters = new DynamicParameters();
			parameters.Add("@appUserID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query,parameters);
				return values.ToList();
			}
		}
	}
}
