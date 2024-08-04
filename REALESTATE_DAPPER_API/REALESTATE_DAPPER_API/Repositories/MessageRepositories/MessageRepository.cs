using Dapper;
using REALESTATE_DAPPER_API.Dtos.CategoryDtos;
using REALESTATE_DAPPER_API.Dtos.MessageDtos;
using REALESTATE_DAPPER_API.Models.dappercontext;

namespace REALESTATE_DAPPER_API.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Models.dappercontext.Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultInBoxMessageDto>>GetInBoxLast3MessageListByReceiver(int id)
        {
            string query = "select Top(3) MessageID,Name,Subject,Detail,SendDate,IsRead,UserImageUrl,Sender,Receiver from Message Inner Join AppUsers On Message.Sender=AppUsers.UserID where Receiver=@receiverId Order By MessageID Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@receiverId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInBoxMessageDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
