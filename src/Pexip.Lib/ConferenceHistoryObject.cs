using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pexip.Lib
{
    /// <summary>
    /// Models the Pexip API reponse for /api/admin/history/v1/conferences/.
    /// </summary>
    public class ConferenceHistoryObject
    {
        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("instant_message_count")]
        public int InstantMessageCount { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("participant_count")]
        public int ParticipantCount { get; set; }

        [JsonProperty("participants")]
        public List<string> Participants { get; set; }

        [JsonProperty("resource_uri")]
        public string ResourceUri { get; set; }

        [JsonProperty("service_type")]
        public string ServiceType { get; set; }

        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}
