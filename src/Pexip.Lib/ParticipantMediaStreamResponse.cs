using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pexip.Lib
{
    public class ParticipantMediaStreamResponse
    {
        [JsonProperty(PropertyName = "meta")]
        public MetaObject MetaObject { get; set; }

        [JsonProperty(PropertyName = "objects")]
        public List<ParticipantMediaStreamObject> ParticipantMediaStreamObject { get; set; }
    }
}
