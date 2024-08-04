
using REALESTATE_DAPPER_API.Dtos.TestimonialDtos;

namespace REALESTATE_DAPPER_API.Repositories.TestimonailRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();

    }
}
