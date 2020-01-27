using System;
using Newtonsoft.Json;

namespace project_ramverket.Models
{
    public class FactModel
    {
        [JsonProperty("text")]
        public string text { get; set; }
        [JsonProperty("used")]
        public bool used { get; set; }
        [JsonProperty("source")]
        public string source { get; set; }
        [JsonProperty("type")]
        public string type { get; set; }
        public bool deleted { get; set; }
        public string _id { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime createdAt { get; set; }
        public string user { get; set; }
        public int __v { get; set; }
        public Status status { get; set; }
    }
}
