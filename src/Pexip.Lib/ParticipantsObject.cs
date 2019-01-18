using Newtonsoft.Json;
using System;

namespace Pexip.Lib
{
    public class ParticipantsObject
    {
        [JsonProperty(PropertyName = "bandwidth")]
        public int Bandwidth { get; set; }

        [JsonProperty(PropertyName = "call_direction")]
        public string CallDirection { get; set; }

        [JsonProperty(PropertyName = "call_quality")]
        public string CallQuality { get; set; }

        [JsonProperty(PropertyName = "call_uuid")]
        public string CallUuid { get; set; }

        [JsonProperty(PropertyName = "conference")]
        public string Conference { get; set; }

        [JsonProperty(PropertyName = "connect_time")]
        public DateTime ConnectTime { get; set; }

        [JsonProperty(PropertyName = "conversation_id")]
        public string ConversationId { get; set; }

        [JsonProperty(PropertyName = "destination_alias")]
        public string DestinationAlias { get; set; }

        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "encryption")]
        public string Encryption { get; set; }

        [JsonProperty(PropertyName = "has_media")]
        public bool HasMedia { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string PexipId { get; set; }

        [JsonProperty(PropertyName = "is_muted")]
        public bool IsMuted { get; set; }

        [JsonProperty(PropertyName = "is_on_hold")]
        public bool IsOnHold { get; set; }

        [JsonProperty(PropertyName = "is_presentation_supported")]
        public bool IsPresentationSupported { get; set; }

        [JsonProperty(PropertyName = "is_presenting")]
        public bool IsPresenting { get; set; }

        [JsonProperty(PropertyName = "is_streaming")]
        public bool IsStreaming { get; set; }

        [JsonProperty(PropertyName = "license_count")]
        public int LicenseCount { get; set; }

        [JsonProperty(PropertyName = "license_type")]
        public string LicenseType { get; set; }

        [JsonProperty(PropertyName = "media_node")]
        public string MediaNode { get; set; }

        [JsonProperty(PropertyName = "parent_id")]
        public string ParentId { get; set; }

        [JsonProperty(PropertyName = "participant_alias")]
        public string ParticipantAlias { get; set; }

        [JsonProperty(PropertyName = "protocol")]
        public string Protocol { get; set; }

        [JsonProperty(PropertyName = "proxy_node")]
        public string ProxyNode { get; set; }

        [JsonProperty(PropertyName = "remote_address")]
        public string RemoteAddress { get; set; }

        [JsonProperty(PropertyName = "remote_port")]
        public int RemotePort { get; set; }

        [JsonProperty(PropertyName = "resource_uri")]
        public string ResourceUri { get; set; }

        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }

        [JsonProperty(PropertyName = "service_tag")]
        public string ServiceTag { get; set; }

        [JsonProperty(PropertyName = "service_type")]
        public string ServiceType { get; set; }

        [JsonProperty(PropertyName = "signalling_node")]
        public string SignallingNode { get; set; }

        [JsonProperty(PropertyName = "source_alias")]
        public string SourceAlias { get; set; }

        [JsonProperty(PropertyName = "system_location")]
        public string SystemLocation { get; set; }

        [JsonProperty(PropertyName = "PropertyName")]
        public string Vendor { get; set; }
    }
}
