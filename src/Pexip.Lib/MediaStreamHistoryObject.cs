using Newtonsoft.Json;

namespace Pexip.Lib
{
    public class MediaStreamHistoryObject
    {
        [JsonProperty("end_time")]
        public string EndTime { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("node")]
        public string Node { get; set; }

        [JsonProperty("participant")]
        public string Participant { get; set; }

        [JsonProperty("rx_bitrate")]
        public int RxBitrate { get; set; }

        [JsonProperty("rx_codec")]
        public string RxCodec { get; set; }

        [JsonProperty("rx_packet_loss")]
        public double RxPacketLoss { get; set; }

        [JsonProperty("rx_packets_lost")]
        public int RxPacketsLost { get; set; }

        [JsonProperty("rx_packets_received")]
        public int RxPacketsReceived { get; set; }

        [JsonProperty("rx_resolution")]
        public string RxResolution { get; set; }

        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        [JsonProperty("stream_id")]
        public string StreamId { get; set; }

        [JsonProperty("stream_type")]
        public string StreamType { get; set; }

        [JsonProperty("tx_bitrate")]
        public int TxBitrate { get; set; }

        [JsonProperty("tx_codec")]
        public string TxCodec { get; set; }

        [JsonProperty("tx_packet_loss")]
        public double TxPacketLoss { get; set; }

        [JsonProperty("tx_packets_lost")]
        public int TxPacketsLost { get; set; }

        [JsonProperty("tx_packets_sent")]
        public int TxPacketsSent { get; set; }

        [JsonProperty("tx_resolution")]
        public string TxResolution { get; set; }
    }
}
