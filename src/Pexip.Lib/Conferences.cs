using Newtonsoft.Json;
using Pexip.Lib.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pexip.Lib
{
    public class Conferences : IConferences
    {
        private readonly HttpClient _httpClient;
        private string _apiConference = "/api/admin/status/v1/conference/";
        public string ApiUri { get; private set; }

        public Conferences(HttpClient httpClient, string apiUri)
        {
            _httpClient = httpClient;
            ApiUri = apiUri;
        }

        public async Task<int> GetTotal()
        {
            var stringTask = await _httpClient.GetAsync(new Uri(ApiUri + _apiConference));

            ConferenceResponse conferencesResponse = new ConferenceResponse();

            conferencesResponse = JsonConvert.DeserializeObject<ConferenceResponse>(stringTask.Content.ReadAsStringAsync().Result);

            return conferencesResponse.MetaObject.TotalCount;
        }
    }
}
