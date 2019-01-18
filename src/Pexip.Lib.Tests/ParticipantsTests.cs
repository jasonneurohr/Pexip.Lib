using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Pexip.Lib.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pexip.Lib.Tests
{
    public class ParticipantsTests
    {
        [Fact]
        public void TestGettingParticipantsList()
        {
            // Arrange

            // The URI we are using in the test
            var requestUri = new Uri("https://localhost/api/admin/status/v1/participant/");

            // Setup object for JSON serialisation to feed into the Get() method
            ParticipantsObject participantOne = new ParticipantsObject
            {
                Bandwidth = 64,
                CallDirection = "in",
                CallQuality = "1_good"
            };

            List<ParticipantsObject> testParticipantsList = new List<ParticipantsObject>();
            testParticipantsList.Add(participantOne);

            MetaObject MetaObject = new MetaObject
            {
                Next = null
            };

            ParticipantsResponse ParticipantsResponse = new ParticipantsResponse
            {
                MetaObject = MetaObject,
                ParticipantsObject = testParticipantsList
            };

            // Serialise the object
            var expectedResponse = JsonConvert.SerializeObject(ParticipantsResponse);

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
            Participants participants = new Participants(client, "https://localhost");

            // Act

            var participantsResult = participants.Get().Result;

            // Assert

            // Assert that a List of participants was returned with 1 item
            Assert.True(participantsResult.Count == 1);
        }

        [Fact]
        public void TestGettingPagedParticipantsList()
        {
            // Arrange

            // The URI we are using in the test
            var requestUri = new Uri("https://localhost/api/admin/status/v1/participant/");
            var requestUriTwo = new Uri("https://localhost/api/admin/status/v1/participant/?limit=20&offset=20");

            // Page 1
            List<ParticipantsObject> testParticipantsList = new List<ParticipantsObject>();
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });

            MetaObject MetaObject = new MetaObject
            {
                Next = "/api/admin/status/v1/participant/?limit=20&offset=20"
            };

            ParticipantsResponse ParticipantsResponse = new ParticipantsResponse
            {
                MetaObject = MetaObject,
                ParticipantsObject = testParticipantsList
            };

            // Page 2
            List<ParticipantsObject> testParticipantsListTwo = new List<ParticipantsObject>();
            testParticipantsListTwo.Add(new ParticipantsObject { CallQuality = "4_terrible" });

            MetaObject MetaObjectTwo = new MetaObject
            {
                Next = null
            };

            ParticipantsResponse ParticipantsResponseTwo = new ParticipantsResponse
            {
                MetaObject = MetaObjectTwo,
                ParticipantsObject = testParticipantsListTwo
            };

            // Serialise the object
            var expectedResponse = JsonConvert.SerializeObject(ParticipantsResponse);
            var expectedResponseTwo = JsonConvert.SerializeObject(ParticipantsResponseTwo);

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
            Participants participants = new Participants(client, "https://localhost");

            // Act

            var participantsResult = participants.Get().Result;

            // Assert

            // Assert that a List of participants was returned with 21 items
            Assert.True(participantsResult.Count == 21);
        }

        [Fact]
        public void TestGettingParticipantListWithTerribleQualityOnly()
        {
            // Arrange

            // The URI we are using in the test
            var requestUri = new Uri("https://localhost/api/admin/status/v1/participant/");

            List<ParticipantsObject> testParticipantsList = new List<ParticipantsObject>();
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "2_ok" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "3_bad" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "4_terrible" });
            testParticipantsList.Add(new ParticipantsObject { CallQuality = "1_good" });

            MetaObject MetaObject = new MetaObject
            {
                Next = null
            };

            ParticipantsResponse ParticipantsResponse = new ParticipantsResponse
            {
                MetaObject = MetaObject,
                ParticipantsObject = testParticipantsList
            };

            // Serialise the object
            var expectedResponse = JsonConvert.SerializeObject(ParticipantsResponse);

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
            IParticipants participants = new Participants(client, "https://localhost");

            // Act

            var participantsResult = participants.Get("4_terrible").Result;

            // Assert

            // Assert that a List of participants was returned with 1 item
            Assert.True(participantsResult.Count == 1);
        }

        [Fact]
        public void TestGettingTotalCountOfParticipant()
        {
            // Arrange

            // The URI we are using in the test
            var requestUri = new Uri("https://localhost/api/admin/status/v1/participant/");

            ParticipantsResponse ParticipantsResponse = new ParticipantsResponse
            {
                MetaObject = new MetaObject { TotalCount = 15 }
            };

            // Serialise the object
            var expectedResponse = JsonConvert.SerializeObject(ParticipantsResponse);

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
            Participants participants = new Participants(client, "https://localhost");

            // Act

            var participantsTotalCount = participants.GetTotal().Result;

            // Assert

            Assert.True(participantsTotalCount == 15);
        }

        [Fact]
        public void TestGettingParticipantMediaStreams()
        {
            // Arrange

            // The URI we are using in the test
            var requestUri = new Uri("https://localhost/api/admin/status/v1/participant/f2e8df3d-cbb4-43bd-be19-e4f5633393d3/media_stream/");

            List<ParticipantMediaStreamObject> streams = new List<ParticipantMediaStreamObject>();
            streams.Add(new ParticipantMediaStreamObject {
                RxJitter = 55,
                RxPacketLoss = 10,
                TxCodec = "opus",
                TxPacketLoss = 0.02,
                TxJitter = 1.49
            });
            streams.Add(new ParticipantMediaStreamObject {
                RxJitter = 55,
                RxPacketLoss = 10,
                RxCodec = "opus",
                TxPacketLoss = 0.02,
                TxJitter = 1.49
            });

            MetaObject MetaObject = new MetaObject
            {
                Next = null
            };

            ParticipantMediaStreamResponse participantsMediaStreamModel = new ParticipantMediaStreamResponse
            {
                MetaObject = MetaObject,
                ParticipantMediaStreamObject = streams
            };

            // Serialise the object
            var expectedResponse = JsonConvert.SerializeObject(participantsMediaStreamModel);

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
            IParticipants participants = new Participants(client, "https://localhost");

            // Act

            var participantMediaStreamResult = participants.GetMediaStreams("f2e8df3d-cbb4-43bd-be19-e4f5633393d3").Result;

            // Assert

            // Assert that a List of participants was returned with 1 item
            Assert.True(participantMediaStreamResult.Count == 2);
        }
    }
}