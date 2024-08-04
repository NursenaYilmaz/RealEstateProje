namespace REALESTATE_DAPPER_UI.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public int productId { get; set; }

        public int AppUserID { get; set; }
        public string productTitle { get; set; }
        public decimal productPrice { get; set; }
        public string productCity { get; set; }
        public string productDistrict { get; set; }
        public string categoryName { get; set; }

        public string ProductCoverImage { get; set; }

        public string Type { get; set; }

        public string ProductAddress { get; set; }
    }
}
