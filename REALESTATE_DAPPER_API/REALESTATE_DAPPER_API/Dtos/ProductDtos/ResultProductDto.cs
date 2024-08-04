namespace REALESTATE_DAPPER_API.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int ProductID {  get; set; }
        public int AppUserID {  get; set; }
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCity { get; set; }
        public string ProductDistrict { get; set; }
        public string ProductDescription { get; set; }
        public string SlugUrl { get; set; }

        public int ProductCategory { get; set; }


    }
}
