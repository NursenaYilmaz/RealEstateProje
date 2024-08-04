using Dapper;
using REALESTATE_DAPPER_API.Dtos.CategoryDtos;
using REALESTATE_DAPPER_API.Dtos.ProductImageDtos;
using REALESTATE_DAPPER_API.Models.dappercontext;

namespace REALESTATE_DAPPER_API.Repositories.ProductImageRepositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly Models.dappercontext.Context _context;

        public ProductImageRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<GetProductımageByProductIdDto>>GetProductImageByProductId(int id)
        {
            string query = "select*from ProductImage where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductımageByProductIdDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
