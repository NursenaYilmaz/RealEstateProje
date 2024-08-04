using Dapper;
using REALESTATE_DAPPER_API.Dtos.ProductDetailDtos;
using REALESTATE_DAPPER_API.Dtos.ProductDtos;

using REALESTATE_DAPPER_API.Models.dappercontext;

namespace REALESTATE_DAPPER_API.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Models.dappercontext.Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = "insert into Product (ProductTitle,ProductPrice,ProductCity,ProductDistrict,ProductCoverImage,ProductAddress,ProductDescription,Type,DealOfTheDay,AdvertisementDay,ProductStatus,ProductCategory,AppUserID)values" +
                " (@productTitle,@productPrice,@productCity,@productDistrict,@productCoverImage,@productAddress,@productDescription,@type,@dealOfTheDay,@advertisementDay,@productStatus,@productCategory,@appUserID)";
            var parameters = new DynamicParameters();
            parameters.Add("@productTitle", createProductDto.ProductTitle);
            parameters.Add("@productPrice", createProductDto.ProductPrice);
            parameters.Add("@productCity", createProductDto.ProductCity);
            parameters.Add("@productDistrict", createProductDto.ProductDistrict);
            parameters.Add("@productCoverImage", createProductDto.ProductCoverImage);
            parameters.Add("@productAddress", createProductDto.ProductAddress);
            parameters.Add("@productDescription", createProductDto.ProductDescription);
            parameters.Add("@type", createProductDto.Type);
            parameters.Add("@dealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("@advertisementDay", createProductDto.AdvertisementDay);
            parameters.Add("@productStatus", createProductDto.ProductStatus);
            parameters.Add("@productCategory", createProductDto.ProductCategory);
            parameters.Add("@appUserID", createProductDto.AppUserID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "select *from Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "select ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,CategoryName,ProductCoverImage,Type,ProductAddress,DealOfTheDay,SlugUrl from Product inner join Category on Product.ProductCategory" +
                "=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast3ProductWithCategoryDto>> GetLast3ProductAsync()
        {
            string query = "select top(3) ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,ProductCategory,CategoryName,AdvertisementDay,ProductCoverImage,ProductDescription from Product Inner Join Category on Product.ProductCategory=Category.CategoryID order by ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "select top(5) ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,ProductCategory,CategoryName,AdvertisementDay,AppUserID from Product Inner Join Category on Product.ProductCategory=Category.CategoryID where Type='kiralık'  order by ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = "select ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,CategoryName,ProductCoverImage,Type,ProductAddress,DealOfTheDay,AppUserID from Product inner join Category on Product.ProductCategory" +
               "=Category.CategoryID where AppUserID=@appUserID and ProductStatus=0";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = "select ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,CategoryName,ProductCoverImage,Type,ProductAddress,DealOfTheDay,AppUserID from Product inner join Category on Product.ProductCategory" +
               "=Category.CategoryID where AppUserID=@appUserID and ProductStatus=1";
            var parameters = new DynamicParameters();
            parameters.Add("@appUserID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategoryAsync()
        {
            string query = "select ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,CategoryName,ProductCoverImage,Type,ProductAddress,DealOfTheDay from Product inner join Category on Product.ProductCategory" +
                "=Category.CategoryID where DealOfTheDay=1";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetProductByProductIdDto> GetProductByProductId(int id)
        {
            string query = "select ProductID,ProductTitle,ProductPrice,ProductCity,ProductDistrict,CategoryName,ProductCoverImage,Type,ProductAddress,ProductDescription,DealOfTheDay,AdvertisementDay,SlugUrl from Product inner join Category on Product.ProductCategory" +
               "=Category.CategoryID where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            
                {
                var values = await connection.QueryAsync<GetProductByProductIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
            }

        public async Task<GetProductDetailByIdDto> GetProductDetailByProductId(int id)
        {
            string query = "select * From ProductDetails Where ProductId=@productID";
                
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())

            {
                var values = await connection.QueryAsync<GetProductDetailByIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            
                {
                await connection.ExecuteAsync(query, parameters);
            }
            
        }
        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
            {

                string query = "Update Product Set DealOfTheDay=1 where ProductID=@productID";
                var parameters = new DynamicParameters();
                parameters.Add("@productID", id);
                using (var connection = _context.CreateConnection())
                
                    {
                        await connection.ExecuteAsync(query, parameters);
                    }
                
            }

        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            string query = "select * From Product Where ProductTitle like '%"+searchKeyValue+"%' And ProductCategory=@propertyCategoryId and ProductCity=@city";

            var parameters = new DynamicParameters();
            parameters.Add("@searchKeyValue", searchKeyValue);
            parameters.Add("@propertyCategoryId", propertyCategoryId);
            parameters.Add("@city", city);
            using (var connection = _context.CreateConnection())

            {
                var values = await connection.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                return values.ToList();
            }
        }
    }

    }


