using REALESTATE_DAPPER_API.Dtos.MessageDtos;

namespace REALESTATE_DAPPER_API.Repositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<List<ResultInBoxMessageDto>> GetInBoxLast3MessageListByReceiver(int id);
    }
}
