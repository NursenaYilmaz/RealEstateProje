using REALESTATE_DAPPER_API.Dtos.AppUserDtos;

namespace REALESTATE_DAPPER_API.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<GetAppUserByProductIdDto> GetAppUserByProductId(int id);
    }
}
