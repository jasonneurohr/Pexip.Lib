using Pexip.Lib.Models;
using System;
using System.Net.Http;

namespace Pexip.Lib
{
    public class ManagerNode : IManagerNode
    {
        public string ApiUser { private get; set; }
        public string ApiPass { private get; set; }
        public string NodeAddress { private get; set; }
        public IParticipants Participants { get; private set; }
        public IParticipantHistory ParticipantHistory { get; private set; }
        public IConferences Conferences { get; private set; }
        public IConferenceHistory ConferenceHistory { get; private set; }

        private string _apiUri;
        
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;


        public ManagerNode(string apiUser, string apiPass, string nodeAddress)
        {
            ApiUser = apiUser ?? throw new ArgumentNullException(nameof(apiUser));
            ApiPass = apiPass ?? throw new ArgumentNullException(nameof(apiPass));
            NodeAddress = nodeAddress ?? throw new ArgumentNullException(nameof(nodeAddress));

            _apiUri = "https://" + nodeAddress;

            _httpClientFactory = new HttpClientFactory();
            _httpClient = _httpClientFactory.NewClient(ApiUser, ApiPass);

            Participants = new Participants(_httpClient, _apiUri);
            ParticipantHistory = new ParticipantHistory(_httpClient, _apiUri);
            Conferences = new Conferences(_httpClient, _apiUri);
            ConferenceHistory = new ConferenceHistory(_httpClient, _apiUri);
        }
    }
}
