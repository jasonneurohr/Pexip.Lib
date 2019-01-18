using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Pexip.Lib.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pexip.Lib.Tests
{
    public class ConferencesTests
    {
        [Fact]
        public void TestGettingTotalCountOfConferences()
        {
            // Arrange

            // The URI we are using in the test
            var requestUri = new Uri("https://localhost/api/admin/status/v1/conference/");

            ConferenceResponse conferencesModel = new ConferenceResponse
            {
                MetaObject = new MetaObject { TotalCount = 15 }
            };

            // Serialise the object
            var expectedResponse = JsonConvert.SerializeObject(conferencesModel);

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
            IConferences conferences = new Conferences(client, "https://localhost");

            // Act

            var conferencesTotalCount = conferences.GetTotal().Result;

            // Assert

            Assert.True(conferencesTotalCount == 15);
        }
    }
}
