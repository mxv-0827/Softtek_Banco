using ÄPI.Services.APIs.DolarAPI;
using Newtonsoft.Json;

namespace ÄPI.Services.APIs.BitcoinAPI
{
    public class BitcoinPrice
    {
        private static readonly string APIKey = "API_KEY99E68UDM2BZI1QIGX4LVAY5DH4L3TTIN";
        private static readonly string BaseUrl = "https://api.finage.co.uk/last/crypto";

        [JsonProperty("price")]
        public decimal BTCPrice { get; set; }


        public static async Task<object?> GetBitcoinPrice() //Get the buy and sell dollarPrice in pesos.
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await client.GetAsync($"{BaseUrl}/btcusd?apikey={APIKey}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BitcoinPrice>(json);
            }

            throw new Exception();
        }
    }
}
