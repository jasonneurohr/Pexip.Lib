using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pexip.Lib
{
    public class ParticipantHistoryObject
    {
        [JsonProperty("av_id")]
        public string AvId { get; set; }

        [JsonProperty("bandwidth")]
        public int Bandwidth { get; set; }

        [JsonProperty("call_direction")]
        public string CallDirection { get; set; }

        [JsonProperty("call_quality")]
        public string CallQuality { get; set; }

        [JsonProperty("call_uuid")]
        public string CallUuid { get; set; }

        [JsonProperty("conference")]
        public string Conference { get; set; }

        [JsonProperty("conference_name")]
        public string ConferenceName { get; set; }

        [JsonProperty("conversation_id")]
        public string ConversationId { get; set; }

        [JsonProperty("disconnect_reason")]
        public string DisconnectReason { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("encryption")]
        public string Encryption { get; set; }

        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        [JsonProperty("has_media")]
        public bool HasMedia { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_streaming")]
        public bool IsStreaming { get; set; }

        [JsonProperty("license_count")]
        public int LicenseCount { get; set; }

        [JsonProperty("license_type")]
        public string LicenseType { get; set; }

        [JsonProperty("local_alias")]
        public string LocalAlias { get; set; }

        [JsonProperty("media_node")]
        public string MediaNode { get; set; }

        [JsonProperty("media_streams")]
        public List<MediaStreamHistoryObject> MediaStreams { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("presentation_id")]
        public string PresentationId { get; set; }

        [JsonProperty("protocol")]
        public string Protocol { get; set; }

        [JsonProperty("proxy_node")]
        public string ProxyNode { get; set; }

        [JsonProperty("remote_address")]
        public string RemoteAddress { get; set; }

        [JsonProperty("remote_alias")]
        public string RemoteAlias { get; set; }

        [JsonProperty("remote_port")]
        public int RemotePort { get; set; }

        [JsonProperty("resource_uri")]
        public string ResourceUri { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("service_tag")]
        public string ServiceTag { get; set; }

        [JsonProperty("service_type")]
        public string ServiceType { get; set; }

        [JsonProperty("signalling_node")]
        public string SignallingNode { get; set; }

        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("system_location")]
        public string SystemLocation { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }
    }
}
