using REALESTATE_DAPPER_API.Dtos.BottomGridDtos;
using REALESTATE_DAPPER_API.Dtos.ServiceDtos;

namespace REALESTATE_DAPPER_API.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGrid();
        Task CreateBottomGrid(CreateBottomGridDto createBottomGridDto);
        Task DeleteBottomGrid(int id);

        Task UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto);
        Task<GetBottomGridDto> GetBottomGrid(int id);

    }
}
