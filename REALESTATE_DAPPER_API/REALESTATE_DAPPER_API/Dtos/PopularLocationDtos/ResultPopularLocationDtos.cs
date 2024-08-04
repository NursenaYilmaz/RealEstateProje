namespace REALESTATE_DAPPER_API.Dtos.PopularLocationDtos
{
    public class ResultPopularLocationDtos
    {
        public int LocationID { get; set; }
        public int PropertyCount { get; set; }

        public string CityName { get; set; }

        public string ImageUrl { get; set; }
    }
}
