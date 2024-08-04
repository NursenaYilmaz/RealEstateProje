using Dapper;
using REALESTATE_DAPPER_API.Dtos.AppUserDtos;
using REALESTATE_DAPPER_API.Dtos.CategoryDtos;
using REALESTATE_DAPPER_API.Models.dappercontext;

namespace REALESTATE_DAPPER_API.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Models.dappercontext.Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }
        public async Task<GetAppUserByProductIdDto> GetAppUserByProductId(int id)
        {
            string query = "select*from AppUsers where UserID=@userID";
            var parameters = new DynamicParameters();
            parameters.Add("@userID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetAppUserByProductIdDto>(query, parameters);
                return values;
            }
        }
    }
}
