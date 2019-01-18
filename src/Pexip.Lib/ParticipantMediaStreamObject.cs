using Newtonsoft.Json;

namespace Pexip.Lib
{
    public class ParticipantMediaStreamObject
    {
        [JsonProperty(PropertyName = "end_time")]
        public string EndTime { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string StreamId { get; set; }

        [JsonProperty(PropertyName = "node")]
        public string Node { get; set; }

        [JsonProperty(PropertyName = "rx_bitrate")]
        public int RxBitrate { get; set; }

        [JsonProperty(PropertyName = "rx_codec")]
        public string RxCodec { get; set; }

        [JsonProperty(PropertyName = "rx_jitter")]
        public double RxJitter { get; set; }

        [JsonProperty(PropertyName = "rx_packet_loss")]
        public double RxPacketLoss { get; set; }

        [JsonProperty(PropertyName = "rx_packets_lost")]
        public int RxPacketsLost { get; set; }

        [JsonProperty(PropertyName = "rx_packets_received")]
        public int RxPacketsReceived { get; set; }

        [JsonProperty(PropertyName = "rx_resolution")]
        public string RxResolution { get; set; }

        [JsonProperty(PropertyName = "rx_windowed_packet_loss")]
        public double RxWindowedPacketLoss { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        public string StartTime { get; set; }

        [JsonProperty(PropertyName = "tx_bitrate")]
        public int TxBitrate { get; set; }

        [JsonProperty(PropertyName = "tx_codec")]
        public string TxCodec { get; set; }

        [JsonProperty(PropertyName = "tx_jitter")]
        public double TxJitter { get; set; }

        [JsonProperty(PropertyName = "tx_packet_loss")]
        public double TxPacketLoss { get; set; }

        [JsonProperty(PropertyName = "tx_packets_lost")]
        public int TxPacketsLost { get; set; }

        [JsonProperty(PropertyName = "tx_packets_sent")]
        public int TxPacketsSent { get; set; }

        [JsonProperty(PropertyName = "tx_resolution")]
        public string TxResolution { get; set; }

        [JsonProperty(PropertyName = "tx_windowed_packet_loss")]
        public double TxWindowedPacketLoss { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string StreamType { get; set; }
    }
}
