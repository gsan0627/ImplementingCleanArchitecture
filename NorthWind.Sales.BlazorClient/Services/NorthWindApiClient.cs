using NorthWind.Sales.BlazorClient.Exceptions;
using NorthWind.Sales.DTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace NorthWind.Sales.BlazorClient.Services
{
    public class NorthWindApiClient
    {
        readonly HttpClient _httpClient;
        public NorthWindApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> CreateOrder(CreateOrderDTO order)
        {
            int orderId = 0;

            var response = await _httpClient.PostAsJsonAsync("create", order);
            if (response.IsSuccessStatusCode)
            {
                orderId = await response.Content.ReadFromJsonAsync<int>();
            }
            else
            {
                throw await GetException(response);
            }

            return orderId;
        }

        private async Task<HttpCustomException> GetException(
            HttpResponseMessage response)
        {
            var jsonContent =
                await response.Content.ReadFromJsonAsync<JsonElement>();

            var problemDetails =
                JsonSerializer.Deserialize<ProblemDetails>(
                    jsonContent.GetRawText(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true });

            if (jsonContent.TryGetProperty("invalid-params", out JsonElement invalidParams))
            {
                problemDetails.InvalidParams =
                    JsonSerializer.Deserialize<Dictionary<string, string>>(
                        invalidParams.GetRawText());
            }

            return new HttpCustomException(problemDetails);

        }
    }
}
