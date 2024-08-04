namespace REALESTATE_DAPPER_API.Dtos.ProductDtos
{
    public class GetProductByProductIdDto
    {
        public int ProductID { get; set; }
        public int AppUserID { get; set; }
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }

        public string CategoryName { get; set; }
        public string ProductDescription { get; set; }

        public string ProductCoverImage { get; set; }

        public string Type { get; set; }

        public string ProductAddress { get; set; }
        public string SlugUrl { get; set; }

        public bool DealOfTheDay { get; set; }

        public DateTime AdvertisementDay { get; set; }
    }
}
