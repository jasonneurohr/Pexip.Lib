using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pexip.Lib
{
    public class ConferenceHistoryResponse
    {
        [JsonProperty("meta")]
        public MetaObject MetaObject { get; set; }

        [JsonProperty("objects")]
        public List<ConferenceHistoryObject> ConferenceHistoryObject { get; set; }
    }
}
