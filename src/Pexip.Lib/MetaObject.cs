using Newtonsoft.Json;

namespace Pexip.Lib
{
    /// <summary>
    /// All Pexip API responses begin with a MetaObject object.
    /// </summary>
    public class MetaObject
    {
        [JsonProperty(PropertyName = "limit")]
        public int Limit { get; set; }

        [JsonProperty(PropertyName = "next")]
        public object Next { get; set; }

        [JsonProperty(PropertyName = "offset")]
        public int Offset { get; set; }

        [JsonProperty(PropertyName = "previous")]
        public object Previous { get; set; }

        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; set; }
    }
}
