using Newtonsoft.Json;

namespace BGD.Media.Extractor.Entities._1._0.Requests
{
    public class ExtractRequest
    {
        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }
    }
}
