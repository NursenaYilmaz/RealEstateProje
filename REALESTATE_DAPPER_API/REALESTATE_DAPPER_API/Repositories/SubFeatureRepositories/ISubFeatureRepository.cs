using REALESTATE_DAPPER_API.Dtos.SubFeatureDtos;

namespace REALESTATE_DAPPER_API.Repositories.SubFeatureRepositories
{
    public interface ISubFeatureRepository
    {
        Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync();
    }
}
