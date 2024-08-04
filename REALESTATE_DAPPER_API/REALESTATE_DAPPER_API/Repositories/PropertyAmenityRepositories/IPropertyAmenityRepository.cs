using REALESTATE_DAPPER_API.Dtos.PropertyAmenityDtos;

namespace REALESTATE_DAPPER_API.Repositories.PropertyAmenityRepositories
{
    public interface IPropertyAmenityRepository
    {
       Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id);
    }
}
