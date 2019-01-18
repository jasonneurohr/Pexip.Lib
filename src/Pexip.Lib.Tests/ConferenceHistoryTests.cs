using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pexip.Lib.Tests
{
    public class ConferenceHistoryTests
    {
        [Fact]
        public void TestGettingTotalCountOfConferencesFromTheHistoryAPI()
        {
            // Arrange

            var timeFilterStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).AddDays(-1).ToString("yyyy-MM-ddTHH:mm:ss");
            var timeFilterEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0).ToString("yyyy-MM-ddTHH:mm:ss");

            // The URI we are using in the test
            var requestUri = new Uri($"https://localhost/api/admin/history/v1/conference/?limit=500&end_time__gte={timeFilterStart}&end_time__lt={timeFilterEnd}");

            ConferenceHistoryResponse conferencesHistoryModel = new ConferenceHistoryResponse
            {
                MetaObject = new MetaObject { TotalCount = 15 }
            };

            // Serialise the object
            var expectedResponse = JsonConvert.SerializeObject(conferencesHistoryModel);

            // Set up the mock with the expected response
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(expectedResponse) };
            var mockHandler = new Mock<HttpClientHandler>();
            mockHandler
                .Protected()
                    .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                        ItExpr.Is<HttpRequestMessage>(message => message.RequestUri == requestUri),
                        ItExpr.IsAny<CancellationToken>())
                    .Returns(Task.FromResult(mockResponse));

            // Set up the HttpClient using the mock handler object
            HttpClient client = new HttpClient(mockHandler.Object);

            // Initialise an instance of the Participants class for testing using the HttpClient
            IConferenceHistory conferences = new ConferenceHistory(client, "https://localhost");

            // Act

            var conferencesTotalCount = conferences.GetTotal().Result;

            // Assert

            Assert.True(conferencesTotalCount == 15);
        }
    }
}
