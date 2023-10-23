using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ÄPI.Services.APIs.DolarAPI
{
    public class DollarPrice
    {
        private static readonly string BaseUrl = "https://dolarapi.com";

        [JsonProperty("compra")]
        public int BuyPrice { get; private set; }

        [JsonProperty("venta")]
        public int SellPrice { get; private set; }


        public static async Task<object?> GetDollarPrice() //Get the buy and sell dollarPrice in pesos.
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await client.GetAsync($"{BaseUrl}/v1/dolares/blue");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DollarPrice>(json);
            }

            throw new Exception();
        }
    }
}
