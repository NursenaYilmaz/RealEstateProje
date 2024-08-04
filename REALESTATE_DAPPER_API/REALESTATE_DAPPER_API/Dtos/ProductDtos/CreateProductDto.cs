namespace REALESTATE_DAPPER_API.Dtos.ProductDtos
{
	public class CreateProductDto
	{

			public string ProductTitle { get; set; }
			public int ProductPrice { get; set; }
			public int AppUserID { get; set; }
			public string ProductCity { get; set; }
			public string ProductDistrict { get; set; }
			public int ProductCategory { get; set; }
			public string ProductAddress { get; set; }
			public string ProductDescription { get; set; }
			public string Type { get; set; }
			public string ProductCoverImage { get; set; }
			public bool DealOfTheDay { get; set; }
			public DateTime AdvertisementDay { get; set; }
			public bool ProductStatus { get; set; }
			public int EmployeeID { get; set; }
		}

	}

