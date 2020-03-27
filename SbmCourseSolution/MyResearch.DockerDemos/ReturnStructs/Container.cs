using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MyResearch.DockerDemos.ReturnStructs
{
    public partial class Container
    {
        [JsonProperty("Command")]
        public string Command { get; set; }

        [JsonProperty("CreatedAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("ID")]
        public string Id { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("Labels")]
        public string Labels { get; set; }

        [JsonProperty("LocalVolumes")]
        public long LocalVolumes { get; set; }

        [JsonProperty("Mounts")]
        public string Mounts { get; set; }

        [JsonProperty("Names")]
        public string Names { get; set; }

        [JsonProperty("Networks")]
        public string Networks { get; set; }

        [JsonProperty("Ports")]
        public string Ports { get; set; }

        [JsonProperty("RunningFor")]
        public string RunningFor { get; set; }

        [JsonProperty("Size")]
        public string Size { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }
    }
}
