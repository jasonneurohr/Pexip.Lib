using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pexip.Lib
{
    public class ConferenceHistory : IConferenceHistory
    {
        private readonly HttpClient _httpClient;
        private string _apiConference = "/api/admin/history/v1/conference/?limit=500";
        public string ApiUri { get; private set; }

        public ConferenceHistory(HttpClient httpClient, string apiUri)
        {
            _httpClient = httpClient;
            ApiUri = apiUri;
        }

        /// <summary>
        /// GetTotal returns the "total_count" value returned from the Pexip API for conferences for the last 24 hours. 
        /// </summary>
        /// <returns>Task<int></returns>
        public async Task<int> GetTotal()
        {
            return await GetTotal(
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(-1),
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0));
        }

        /// <summary>
        /// /// GetTotal returns the "total_count" value returned from the Pexip API for conferences for period specified in the paramaters. 
        /// </summary>
        /// <param name="timeFilterStart"></param>
        /// <param name="timeFilterEnd"></param>
        /// <returns>Task<int></returns>
        public async Task<int> GetTotal(DateTime timeFilterStart, DateTime timeFilterEnd)
        {
            var stringTask = await _httpClient.GetAsync(
                new Uri(
                    $"{ApiUri}{_apiConference}&end_time__gte={timeFilterStart.ToString("yyyy-MM-ddTHH:mm:ss")}&end_time__lt={timeFilterEnd.ToString("yyyy-MM-ddTHH:mm:ss")}"));

            ConferenceHistoryResponse conferencesHistoryResponse = new ConferenceHistoryResponse();

            conferencesHistoryResponse = JsonConvert.DeserializeObject<ConferenceHistoryResponse>(stringTask.Content.ReadAsStringAsync().Result);

            return conferencesHistoryResponse.MetaObject.TotalCount;
        }

        public async Task<List<ConferenceHistoryObject>> Get()
        {
            var stringTask = await _httpClient.GetAsync(new Uri(ApiUri + _apiConference));

            ConferenceHistoryResponse conferenceHistoryResponse = new ConferenceHistoryResponse();
            List<ConferenceHistoryObject> conferenceHistoryList = new List<ConferenceHistoryObject>();

            conferenceHistoryResponse = JsonConvert.DeserializeObject<ConferenceHistoryResponse>(stringTask.Content.ReadAsStringAsync().Result);

            // Add all the participant objects to the list
            foreach (var participant in conferenceHistoryResponse.ConferenceHistoryObject)
            {
                conferenceHistoryList.Add(participant);
            }

            // If there are more pages, page through them using the 'next' pointer
            while (conferenceHistoryResponse.MetaObject.Next != null)
            {
                // Use the 'next' pointer to get the next page
                stringTask = await _httpClient.GetAsync(new Uri(ApiUri + conferenceHistoryResponse.MetaObject.Next));
                conferenceHistoryResponse = JsonConvert.DeserializeObject<ConferenceHistoryResponse>(stringTask.Content.ReadAsStringAsync().Result);

                // Add all the participant objects to the list
                foreach (var participant in conferenceHistoryResponse.ConferenceHistoryObject)
                {
                    conferenceHistoryList.Add(participant);
                }
            }

            return conferenceHistoryList;
        }

        public async Task<List<ConferenceHistoryObject>> Get(DateTimeOffset timeFilterStart, DateTimeOffset timeFilterEnd)
        {
            var stringTask = await _httpClient.GetAsync(
                new Uri(
                    $"{ApiUri}{_apiConference}&end_time__gte={timeFilterStart.ToString("yyyy-MM-ddTHH:mm:ss")}&end_time__lt={timeFilterEnd.ToString("yyyy-MM-ddTHH:mm:ss")}"));

            ConferenceHistoryResponse conferenceHistoryResponse = new ConferenceHistoryResponse();
            List<ConferenceHistoryObject> conferenceHistoryList = new List<ConferenceHistoryObject>();

            conferenceHistoryResponse = JsonConvert.DeserializeObject<ConferenceHistoryResponse>(stringTask.Content.ReadAsStringAsync().Result);

            // Add all the participant objects to the list
            foreach (var participant in conferenceHistoryResponse.ConferenceHistoryObject)
            {
                conferenceHistoryList.Add(participant);
            }

            // If there are more pages, page through them using the 'next' pointer
            while (conferenceHistoryResponse.MetaObject.Next != null)
            {
                // Use the 'next' pointer to get the next page
                stringTask = await _httpClient.GetAsync(new Uri(ApiUri + conferenceHistoryResponse.MetaObject.Next));
                conferenceHistoryResponse = JsonConvert.DeserializeObject<ConferenceHistoryResponse>(stringTask.Content.ReadAsStringAsync().Result);

                // Add all the participant objects to the list
                foreach (var participant in conferenceHistoryResponse.ConferenceHistoryObject)
                {
                    conferenceHistoryList.Add(participant);
                }
            }

            return conferenceHistoryList;
        }
    }
}
