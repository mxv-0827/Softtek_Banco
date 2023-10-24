using Newtonsoft.Json;

namespace ÄPI.Services.APIs
{
    public class Result
    {
        [JsonProperty("rate")]
        internal decimal Rate { get; set; }
    }
}
