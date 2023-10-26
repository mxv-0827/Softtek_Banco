using Newtonsoft.Json;
using System.Reflection;

namespace ÄPI.Services.APIs
{
    public class CurrencyConvertionAPI
    {
        private static readonly string APIKey = "cb94088da2-b0b1474052-s303or"; //API KEY lasts only for 7 days. 100.000 available requests for the hole duration of the api_key.
        private static readonly string BaseUrl = "https://api.fastforex.io";

        [JsonProperty("result")]
        public Result ConvertionValue { get; set; }


        public static async Task<decimal> GetCurrencyConvertion(string fromCurrency, string toCurrency, int amount) //Get the converted value of a currency based on other.
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var response = await client.GetAsync($"{BaseUrl}/convert?from={fromCurrency}&to={toCurrency}&amount={amount}&api_key={APIKey}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<CurrencyConvertionAPI>(json);

                return result.ConvertionValue.Rate * amount;
            }

            throw new Exception("An error took place while converting the currencies.");
        }
    }
}
