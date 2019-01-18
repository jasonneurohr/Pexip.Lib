using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pexip.Lib.Models
{
    public class Participants : IParticipants
    {
        private readonly HttpClient _httpClient;
        private string _apiParticipants = "/api/admin/status/v1/participant/";
        public string ApiUri { get; private set; }

        public Participants(HttpClient httpClient, string apiUri)
        {
            _httpClient = httpClient;
            ApiUri = apiUri;
        }

        public async Task<IList<ParticipantsObject>> Get()
        {
            var stringTask = await _httpClient.GetAsync(new Uri(ApiUri + _apiParticipants));

            ParticipantsResponse participantsResponse = new ParticipantsResponse();
            List<ParticipantsObject> participantsList = new List<ParticipantsObject>();

            participantsResponse = JsonConvert.DeserializeObject<ParticipantsResponse>(stringTask.Content.ReadAsStringAsync().Result);

            // Add all the participant objects to the list
            foreach (var participant in participantsResponse.ParticipantsObject)
            {
                participantsList.Add(participant);
            }

            // If there are more pages, page through them using the 'next' pointer
            while (participantsResponse.MetaObject.Next != null)
            {
                // Use the 'next' pointer to get the next page
                stringTask = await _httpClient.GetAsync(new Uri(ApiUri + participantsResponse.MetaObject.Next));
                participantsResponse = JsonConvert.DeserializeObject<ParticipantsResponse>(stringTask.Content.ReadAsStringAsync().Result);
                
                // Add all the participant objects to the list
                foreach (var participant in participantsResponse.ParticipantsObject)
                {
                    participantsList.Add(participant);
                }
            }

            return participantsList;
        }

        public async Task<IList<ParticipantsObject>> Get(string callQuality)
        {
            var participantsList = await Get();
            List<ParticipantsObject> filteredParticipantsList = new List<ParticipantsObject>();

            foreach (var participant in participantsList)
            {
                if (participant.CallQuality.Equals(callQuality))
                {
                    filteredParticipantsList.Add(participant);
                }
            }

            return filteredParticipantsList;
        }

        public async Task<int> GetTotal()
        {
            
            var stringTask = await _httpClient.GetAsync(new Uri(ApiUri + _apiParticipants));
            
            if ((int)stringTask.StatusCode == 200)
            {
                ParticipantsResponse participantsResponse = new ParticipantsResponse();

                participantsResponse = JsonConvert.DeserializeObject<ParticipantsResponse>(stringTask.Content.ReadAsStringAsync().Result);

                return participantsResponse.MetaObject.TotalCount;
            }

            throw new Exception((int)stringTask.StatusCode + " - " + stringTask.ReasonPhrase);
        }

        public async Task<IList<ParticipantMediaStreamObject>> GetMediaStreams(string id)
        {
            var stringTask = await _httpClient.GetAsync(new Uri(ApiUri + _apiParticipants + id + "/media_stream/"));

            ParticipantMediaStreamResponse participantMediaStreamResponse = new ParticipantMediaStreamResponse();
            List<ParticipantMediaStreamObject> participantMediaStreamList = new List<ParticipantMediaStreamObject>();

            participantMediaStreamResponse = JsonConvert.DeserializeObject<ParticipantMediaStreamResponse>(stringTask.Content.ReadAsStringAsync().Result);

            // Add all the participant objects to the list
            foreach (var stream in participantMediaStreamResponse.ParticipantMediaStreamObject)
            {
                participantMediaStreamList.Add(stream);
            }

            return participantMediaStreamList;
        }
    }
}
