using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pexip.Lib
{
    public class ParticipantHistory : IParticipantHistory
    {
        private readonly HttpClient _httpClient;
        private string _apiParticipants = "/api/admin/history/v1/participant/?limit=500";
        public string ApiUri { get; private set; }

        public ParticipantHistory(HttpClient httpClient, string apiUri)
        {
            _httpClient = httpClient;
            ApiUri = apiUri;
        }

        public async Task<IList<ParticipantHistoryObject>> Get()
        {
            var stringTask = await _httpClient.GetAsync(new Uri(ApiUri + _apiParticipants));

            ParticipantHistoryResponse participantHistoryResponse = new ParticipantHistoryResponse();
            List<ParticipantHistoryObject> participantHistoryList = new List<ParticipantHistoryObject>();

            participantHistoryResponse = JsonConvert.DeserializeObject<ParticipantHistoryResponse>(stringTask.Content.ReadAsStringAsync().Result);

            // Add all the participant objects to the list
            foreach (var participant in participantHistoryResponse.ParticipantHistoryObject)
            {
                participantHistoryList.Add(participant);
            }

            // If there are more pages, page through them using the 'next' pointer
            while (participantHistoryResponse.MetaObject.Next != null)
            {
                // Use the 'next' pointer to get the next page
                stringTask = await _httpClient.GetAsync(new Uri(ApiUri + participantHistoryResponse.MetaObject.Next));
                participantHistoryResponse = JsonConvert.DeserializeObject<ParticipantHistoryResponse>(stringTask.Content.ReadAsStringAsync().Result);

                // Add all the participant objects to the list
                foreach (var participant in participantHistoryResponse.ParticipantHistoryObject)
                {
                    participantHistoryList.Add(participant);
                }
            }

            return participantHistoryList;
        }

        public async Task<IList<ParticipantHistoryObject>> Get(DateTimeOffset timeFilterStart, DateTimeOffset timeFilterEnd)
        {
            var stringTask = await _httpClient.GetAsync(
                new Uri(
                    $"{ApiUri}{_apiParticipants}&end_time__gte={timeFilterStart.ToString("yyyy-MM-ddTHH:mm:ss")}&end_time__lt={timeFilterEnd.ToString("yyyy-MM-ddTHH:mm:ss")}"));

            ParticipantHistoryResponse participantHistoryModel = new ParticipantHistoryResponse();
            List<ParticipantHistoryObject> participantHistoryList = new List<ParticipantHistoryObject>();

            participantHistoryModel = JsonConvert.DeserializeObject<ParticipantHistoryResponse>(stringTask.Content.ReadAsStringAsync().Result);

            // Add all the participant objects to the list
            foreach (var participant in participantHistoryModel.ParticipantHistoryObject)
            {
                participantHistoryList.Add(participant);
            }

            // If there are more pages, page through them using the 'next' pointer
            while (participantHistoryModel.MetaObject.Next != null)
            {
                // Use the 'next' pointer to get the next page
                stringTask = await _httpClient.GetAsync(new Uri(ApiUri + participantHistoryModel.MetaObject.Next));
                participantHistoryModel = JsonConvert.DeserializeObject<ParticipantHistoryResponse>(stringTask.Content.ReadAsStringAsync().Result);

                // Add all the participant objects to the list
                foreach (var participant in participantHistoryModel.ParticipantHistoryObject)
                {
                    participantHistoryList.Add(participant);
                }
            }

            return participantHistoryList;
        }
    }
}
