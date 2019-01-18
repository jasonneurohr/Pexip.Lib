using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pexip.Lib.Tests
{
    public class ParticipantHistoryTests
    {
        [Fact]
        public void TestGettingParticipantHistoryList()
        {
            // Arrange

            // The URI we are using in the test
            var requestUri = new Uri("https://localhost/api/admin/history/v1/participant/?limit=500");

            // Setup object for JSON serialisation to feed into the Get() method
            ParticipantHistoryObject participantOne = new ParticipantHistoryObject
            {
                Bandwidth = 64,
                CallDirection = "in",
                CallQuality = "1_good"
            };

            List<ParticipantHistoryObject> testParticipantsList = new List<ParticipantHistoryObject>();
            testParticipantsList.Add(participantOne);

            MetaObject metaModel = new MetaObject
            {
                Next = null
            };

            ParticipantHistoryResponse participantsModel = new ParticipantHistoryResponse
            {
                MetaObject = metaModel,
                ParticipantHistoryObject = testParticipantsList
            };

            // Serialise the object
            var expectedResponse = JsonConvert.SerializeObject(participantsModel);

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
            ParticipantHistory participantHistory = new ParticipantHistory(client, "https://localhost");

            // Act

            var participantsResult = participantHistory.Get().Result;

            // Assert

            // Assert that a List of participants was returned with 1 item
            Assert.True(participantsResult.Count == 1);
        }

        [Fact]
        public void TestGettingPagedParticipantsList()
        {
            // Arrange

            // The URI we are using in the test
            var requestUri = new Uri("https://localhost/api/admin/history/v1/participant/?limit=500");
            var requestUriTwo = new Uri("https://localhost/api/admin/history/v1/participant/?limit=500&offset=20");

            // Page 1
            List<ParticipantHistoryObject> testParticipantsList = new List<ParticipantHistoryObject>();
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantHistoryObject { CallQuality = "1_good" });

            MetaObject metaModel = new MetaObject
            {
                Next = "/api/admin/history/v1/participant/?limit=500&offset=20"
            };

            ParticipantHistoryResponse participantHistoryModel = new ParticipantHistoryResponse
            {
                MetaObject = metaModel,
                ParticipantHistoryObject = testParticipantsList
            };

            // Page 2
            List<ParticipantHistoryObject> testParticipantsListTwo = new List<ParticipantHistoryObject>();
            testParticipantsListTwo.Add(new ParticipantHistoryObject { CallQuality = "4_terrible" });

            MetaObject metaModelTwo = new MetaObject
            {
                Next = null
            };

            ParticipantHistoryResponse participantHistoryModelTwo = new ParticipantHistoryResponse
            {
                MetaObject = metaModelTwo,
                ParticipantHistoryObject = testParticipantsListTwo
            };

            // Serialise the object
            var expectedResponse = JsonConvert.SerializeObject(participantHistoryModel);
            var expectedResponseTwo = JsonConvert.SerializeObject(participantHistoryModelTwo);

            // Set up the mock with the expected response
            var mockResponse = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(expectedResponse) };
            var mockResponseTwo = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(expectedResponseTwo) };
            var mockHandler = new Mock<HttpClientHandler>();
            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(message => message.RequestUri == requestUri),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(mockResponse));

            mockHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(message => message.RequestUri == requestUriTwo),
                    ItExpr.IsAny<CancellationToken>())
                .Returns(Task.FromResult(mockResponseTwo));

            // Set up the HttpClient using the mock handler object
            HttpClient client = new HttpClient(mockHandler.Object);

            // Initialise an instance of the Participants class for testing using the HttpClient
            ParticipantHistory participants = new ParticipantHistory(client, "https://localhost");

            // Act

            var participantsResult = participants.Get().Result;

            // Assert

            // Assert that a List of participants was returned with 21 items
            Assert.True(participantsResult.Count == 21);
        }

    }
}
