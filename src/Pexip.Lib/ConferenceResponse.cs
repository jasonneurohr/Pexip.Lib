using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pexip.Lib
{
    public class ConferenceResponse
    {
        [JsonProperty(PropertyName = "meta")]
        public MetaObject MetaObject { get; set; }

        [JsonProperty(PropertyName = "objects")]
        public List<ConferencesObject> ConferencesObject { get; set; }
    }
}
