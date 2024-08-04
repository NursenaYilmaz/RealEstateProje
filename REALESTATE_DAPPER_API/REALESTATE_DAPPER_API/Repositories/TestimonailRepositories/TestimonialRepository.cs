using Dapper;
using REALESTATE_DAPPER_API.Dtos.TestimonialDtos;
using REALESTATE_DAPPER_API.Models.dappercontext;

namespace REALESTATE_DAPPER_API.Repositories.TestimonailRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Models.dappercontext.Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }
        public  async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "select *from Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }
    }
}
