using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REALESTATE_DAPPER_UI.Dtos.ProductDtos;

namespace REALESTATE_DAPPER_UI.viewcomponents.HomePage
{
    public class _DefaultHomePageProductList : ViewComponent
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public _DefaultHomePageProductList(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client=_HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44343/api/Products/GetProductByDealOfTheDayTrueWithCategory");
            if(responseMessage.IsSuccessStatusCode) 
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);  
                return View(values);
            }
            return View();
        }
    }

}
