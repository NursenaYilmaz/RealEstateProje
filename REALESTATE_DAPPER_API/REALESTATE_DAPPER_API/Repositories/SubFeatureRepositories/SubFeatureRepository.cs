using Dapper;
using REALESTATE_DAPPER_API.Dtos.SubFeatureDtos;
using REALESTATE_DAPPER_API.Models.dappercontext;

namespace REALESTATE_DAPPER_API.Repositories.SubFeatureRepositories
{
    public class SubFeatureRepository : ISubFeatureRepository
    {
        private readonly Models.dappercontext.Context _context;

        public SubFeatureRepository(Context context)
        {
            _context = context;
        }
        public  async Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync()
        {

            string query = "select *from SubFeature";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultSubFeatureDto>(query);
                return values.ToList();
            }
        }
    }
}
