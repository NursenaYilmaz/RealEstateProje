using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REALESTATE_DAPPER_UI.Dtos.EstateAgentDtos;
using REALESTATE_DAPPER_UI.Dtos.ProductDtos;
using REALESTATE_DAPPER_UI.Services;

namespace REALESTATE_DAPPER_UI.ViewComponents.EstateAgent
{
	public class _EstateAgentLastProductsComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILoginService _loginService;

		public _EstateAgentLastProductsComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
		{
			_httpClientFactory = httpClientFactory;
			_loginService = loginService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var id = _loginService.GetUserID;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44343/api/EstateAgentLastProducts?id="+id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultLast5ProductWithCategoryDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
