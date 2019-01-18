using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Pexip.Lib
{
    class HttpClientFactory : IHttpClientFactory
    {
        /// <summary>
        /// Returns a HttpClient object configured with the Basic Authentication Header.
        /// </summary>
        /// <param name="apiUser"></param>
        /// <param name="apiPass"></param>
        /// <returns>HttpClient</returns>
        public HttpClient NewClient(string apiUser, string apiPass)
        {
            var client = new HttpClient();

            // Set auth headers
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(
                    Encoding.ASCII.GetBytes(
                        string.Format(apiUser + ":" + apiPass)
                    )
                )
            );

            // Timeout set to 1 minute to allow for large API responses
            client.Timeout = new TimeSpan(0, 1, 0);

            return client;
        }
    }
}
