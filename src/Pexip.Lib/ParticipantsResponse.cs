using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pexip.Lib
{
    public class ParticipantsResponse
    {
        [JsonProperty(PropertyName = "meta")]
        public MetaObject MetaObject { get; set; }

        [JsonProperty(PropertyName = "objects")]
        public List<ParticipantsObject> ParticipantsObject { get; set; }
    }
}
