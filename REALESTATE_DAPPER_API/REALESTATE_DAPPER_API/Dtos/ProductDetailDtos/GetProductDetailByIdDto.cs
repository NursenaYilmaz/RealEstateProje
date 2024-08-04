namespace REALESTATE_DAPPER_API.Dtos.ProductDetailDtos
{
    public class GetProductDetailByIdDto
    {
        public int ProductDetailsId { get; set; }
        public string productSize { get; set; }
        public int BedroomCount { get; set; }
        public int RoomCount { get;set; }

        public int BathCount { get; set; }
        public int GarageSize { get; set; }

        public int BuildYear { get;set;}
        public int Price { get; set; }
        public string Location { get; set; }
        public string VideoUrl { get; set; }

        public int ProductId { get; set; }

        public DateTime AdvertisementDay { get; set; }

    }
}
