using Newtonsoft.Json;
using System.Collections.Generic;

namespace project_ramverket.Models
{
    public class ImageModel
    {
        [JsonProperty("breeds")]
        public List<object> breeds { get; set; }
        [JsonProperty("categories")]
        public List<Category> categories { get; set; }
        public string id { get; set; }
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("width")]
        public int width { get; set; }
        [JsonProperty("height")]
        public int height { get; set; }
    }
}
