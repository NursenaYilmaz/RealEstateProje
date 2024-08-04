using Dapper;
using REALESTATE_DAPPER_API.Dtos.BottomGridDtos;
using REALESTATE_DAPPER_API.Dtos.ProductDtos;
using REALESTATE_DAPPER_API.Dtos.ServiceDtos;
using REALESTATE_DAPPER_API.Models.dappercontext;

namespace REALESTATE_DAPPER_API.Repositories.BottomGridRepositories
{
    public class BottomGridRepository :IBottomGridRepository
    {
        private readonly Models.dappercontext.Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }
 
        public async Task CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
			string query = "insert into BottomGrid (Icon,Title,Description)values (@ıcon,@title,@description)";
			var parameters = new DynamicParameters();
			parameters.Add("@ıcon", createBottomGridDto.Icon);
			parameters.Add("@title", createBottomGridDto.Title);
			parameters.Add("@description", createBottomGridDto.Description);

			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

        public  async Task DeleteBottomGrid(int id)
        {
			string query = "Delete From BottomGrid Where BottomGridID=@bottomGridID";
			var parameters = new DynamicParameters();
			parameters.Add("@bottomGridID", id);
			using (var connection = _context.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

        public async Task<List<ResultBottomGridDto>> GetAllBottomGrid()
        {
            string query = "select *from BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public  async Task<GetBottomGridDto> GetBottomGrid(int id)
        {
			string query = "select*from BottomGrid where BottomGridID=@bottomGridID";
			var parameters = new DynamicParameters();
			parameters.Add("@bottomGridID", id);
			using (var connection = _context.CreateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, parameters);
				return values;
			}
		}

        public  async Task UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
			string query = "update BottomGrid set Icon=@ıcon,Title=@title,Description=@description where BottomGridID=@bottomGridID ";
			var parameters = new DynamicParameters();

			parameters.Add("@ıcon", updateBottomGridDto.Icon);
			parameters.Add("@title", updateBottomGridDto.Title);
			parameters.Add("@description", updateBottomGridDto.Description);
			parameters.Add("@bottomGridID", updateBottomGridDto.BottomGridID);

			using (var connection = _context.CreateConnection())

			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
    }
}
