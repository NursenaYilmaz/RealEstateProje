namespace REALESTATE_DAPPER_UI.Dtos.ProductDetailDtos
{
    public class GetProductDetailByIdDto
    {
            public int productDetailsId { get; set; }
            public string productSize { get; set; }
            public int bedroomCount { get; set; }
             public int BathCount { get; set; }
             public int roomCount { get; set; }
            public int garageSize { get; set; }
            public int buildYear { get; set; }
            public decimal price { get; set; }
            public string location { get; set; }
            public string videoUrl { get; set; }
            public int productId { get; set; }
            public DateTime AdvertisementDay { get; set; }
    }

    }

