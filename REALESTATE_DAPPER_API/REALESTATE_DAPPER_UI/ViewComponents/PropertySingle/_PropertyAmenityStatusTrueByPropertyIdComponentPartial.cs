﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using REALESTATE_DAPPER_UI.Dtos.PropertyAmenityDtos;

namespace REALESTATE_DAPPER_UI.ViewComponents.PropertySingle
{
    public class _PropertyAmenityStatusTrueByPropertyIdComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _PropertyAmenityStatusTrueByPropertyIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44343/api/PropertyAmenities?id=1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyAmenityByStatusTrueDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
