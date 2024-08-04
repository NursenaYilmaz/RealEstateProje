using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REALESTATE_DAPPER_UI.Dtos.ProductDetailDtos;
using REALESTATE_DAPPER_UI.Dtos.ProductDtos;

namespace REALESTATE_DAPPER_UI.Controllers
{
	public class PropertyController : Controller
	{
        private readonly IHttpClientFactory _HttpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44343/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue,int propertyCategoryId,string city)
        {
            //ViewBag.searchKeyValue = TempData["searchKeyValue"];
            //ViewBag.propertyCategoryId = TempData["propertyCategoryId"];
            //ViewBag.city = TempData["city"];

            //searchKeyValue = TempData["searchKeyValue"].ToString();
            //propertyCategoryId =int.Parse(TempData["propertyCategoryId"].ToString());
            //city = TempData["city"].ToString();
            searchKeyValue = TempData["searchKeyValue"] != null ? TempData["searchKeyValue"].ToString() : string.Empty;
            propertyCategoryId = TempData["propertyCategoryId"] != null ? int.Parse(TempData["propertyCategoryId"].ToString()) : 0;
            city = TempData["city"] != null ? TempData["city"].ToString() : string.Empty;
            var client = _HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44343/api/Products/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult>PropertySingle(string slug,int id)
        {
            ViewBag.i = id;
            var client = _HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44343/api/Products/GetProductByProductId?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ResultProductDtos>(jsonData);
            var responseMessage2 = await client.GetAsync("https://localhost:44343/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);
            ViewBag.title1=values.productTitle.ToString();
            ViewBag.productId=values.productId.ToString();
            ViewBag.price=values.productPrice.ToString();
            ViewBag.city=values.productCity.ToString();
            ViewBag.district=values.productDistrict.ToString();
            ViewBag.address=values.ProductAddress.ToString();
            ViewBag.type=values.Type.ToString();
            ViewBag.slugurl = values.SlugUrl;
            ViewBag.description=values.ProductDescription.ToString();
            ViewBag.roomcount=values2.roomCount.ToString();
            ViewBag.garagesize=values2.garageSize.ToString();
            ViewBag.bathcount=values2.BathCount.ToString();
            ViewBag.bedcount=values2.bedroomCount.ToString();
            ViewBag.size=values2.productSize.ToString();
            ViewBag.builtyear=values2.buildYear.ToString();
            ViewBag.date = values.AdvertisementDay;
            ViewBag.location = values2.location;
            ViewBag.videoUrl = values2.videoUrl;

            DateTime date1 = DateTime.Now;
            DateTime date2 = values.AdvertisementDay;

            TimeSpan timeSpan=date1 - date2;
            int month=timeSpan.Days;

            ViewBag.datediff = month / 30;

            string slugFromTitle = CreateSlug(values.productTitle);
            ViewBag.slugurl = slugFromTitle;
            
            return View();
        }
        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant();
            title = title.Replace(" ", "-");
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", " ");
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim();
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-");
            return title;
        }
    }
}
