using System.Security.Principal;

namespace REALESTATE_DAPPER_UI.Models
{
    public class JwtResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
