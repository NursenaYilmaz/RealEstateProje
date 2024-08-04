using Dapper;
using REALESTATE_DAPPER_API.Dtos.PropertyAmenityDtos;
using REALESTATE_DAPPER_API.Models.dappercontext;

namespace REALESTATE_DAPPER_API.Repositories.PropertyAmenityRepositories
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Models.dappercontext.Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id)
        {
            string query = "select PropertyAmenityID,Title From PropertyAmenity Inner Join Amenity On Amenity.AmenityID=PropertyAmenity.AmenityID Where PropertyID=@propertyID and Status=1";
            var parameters=new DynamicParameters();
            parameters.Add("propertyID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDto>(query,parameters);
                return values.ToList();
            }
        }
    }
}
