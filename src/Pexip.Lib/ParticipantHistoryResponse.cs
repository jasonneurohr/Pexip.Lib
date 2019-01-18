using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pexip.Lib
{
    /// <summary>
    /// Models the Pexip API reponse for /api/admin/history/v1/participant/.
    /// </summary>
    public class ParticipantHistoryResponse
    {
        [JsonProperty(PropertyName = "meta")]
        public MetaObject MetaObject { get; set; }

        [JsonProperty(PropertyName = "objects")]
        public List<ParticipantHistoryObject> ParticipantHistoryObject { get; set; }
    }
}
