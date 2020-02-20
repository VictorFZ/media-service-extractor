using Newtonsoft.Json;

namespace BGD.Media.Extractor.Entities._1._0.Responses
{
    public class ExtractResponse
    {
        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }
    }
}
