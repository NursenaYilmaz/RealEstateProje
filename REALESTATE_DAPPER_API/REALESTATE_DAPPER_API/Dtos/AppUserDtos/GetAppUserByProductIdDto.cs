using Microsoft.Identity.Client;

namespace REALESTATE_DAPPER_API.Dtos.AppUserDtos
{
    public class GetAppUserByProductIdDto
    {
        public int UserID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserImageUrl { get; set; }

    }
}
