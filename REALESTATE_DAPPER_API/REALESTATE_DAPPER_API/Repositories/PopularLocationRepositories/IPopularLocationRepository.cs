using REALESTATE_DAPPER_API.Dtos.BottomGridDtos;
using REALESTATE_DAPPER_API.Dtos.PopularLocationDtos;
using REALESTATE_DAPPER_API.Dtos.PopularLocationDtos;

namespace REALESTATE_DAPPER_API.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDtos>> GetAllPopularLocation();

        Task CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);
        Task DeletePopularLocation(int id);

        Task UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);
		Task<GetByIdPopularLocationDto> GetPopularLocation(int id);

	}
}
