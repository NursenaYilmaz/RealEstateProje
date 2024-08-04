using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REALESTATE_DAPPER_API.Dtos.LoginDtos;
using REALESTATE_DAPPER_API.Models.dappercontext;
using REALESTATE_DAPPER_API.Tools;

namespace REALESTATE_DAPPER_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Models.dappercontext.Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto loginDto)
        {
            string query = "select * from AppUsers where Username=@username and Password=@password";
            string query2 = "select UserID from AppUsers where Username=@username and Password=@password";
            var parameters = new DynamicParameters();
            parameters.Add("@username", loginDto.Username);
            parameters.Add("@password",loginDto.Password);
            using (var connection = _context.CreateConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query,parameters);
                var values2=await connection.QueryFirstAsync<GetAppUserIdDto>(query2,parameters);

                if (values != null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.UserName = values.Username;
                    model.ID = values2.UserID;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return Ok("başarısız");
                }

            }
        }
    }
}
