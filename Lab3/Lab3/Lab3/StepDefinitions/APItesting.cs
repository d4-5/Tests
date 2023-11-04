using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowRestApi.Steps
{
    [Binding]
    public class RestApiTestingSteps
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse response;

        [Given(@"connect to db")]
        public void GivenConnectToDb()
        {
            client = new RestClient("https://restful-booker.herokuapp.com/");

        }

        [Given(@"create get request to (.*)")]
        public void GivenCreateGetRequest(string url)
        {
            request = new RestRequest(url, Method.Get);
        }

        [Given(@"create post request to (.*)")]
        public void GivenCreatePostRequest(string url)
        {
            request = new RestRequest(url, Method.Post);
        }

        [Given(@"include json body that contains new booking")]
        public void GivenJSONNewBooking()
        {
            string newBookingJson = @"
            {
                ""firstname"": ""Jim"",
                ""lastname"": ""Brown"",
                ""totalprice"": 111,
                ""depositpaid"": true,
                ""bookingdates"": {
                    ""checkin"": ""2018-01-01"",
                    ""checkout"": ""2019-01-01""
                },
                ""additionalneeds"": ""Breakfast""
            }";

            request.AddJsonBody(newBookingJson);
        }

        [When(@"send request")]
        public void WhenSendRequest()
        {
            response = client.Execute(request);
        }

        [Then(@"response is success")]
        public void ThenResponseIsSuccess()
        {

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Then(@"json that contains booking")]
        public void ThenResponseShouldContainJSONBooking()
        {
            dynamic responseObject = JsonConvert.DeserializeObject(response.Content);

            JObject expectedJson = JObject.Parse(@"
            {
                ""firstname"": ""Sally"",
                ""lastname"": ""Brown"",
                ""totalprice"": 111,
                ""depositpaid"": true,
                ""bookingdates"": {
                    ""checkin"": ""2013-02-23"",
                    ""checkout"": ""2014-10-23""
                },
                ""additionalneeds"": ""Breakfast""
            }");

            Assert.AreEqual(expectedJson, JObject.FromObject(responseObject.booking));
        }

        [Then(@"json that contains the same booking")]
        public void ThenResponseShouldContainTheSameBooking()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            dynamic responseObject = JsonConvert.DeserializeObject(response.Content);

            JObject expectedJson = JObject.Parse(@"
            {
                ""firstname"": ""Jim"",
                ""lastname"": ""Brown"",
                ""totalprice"": 111,
                ""depositpaid"": true,
                ""bookingdates"": {
                    ""checkin"": ""2018-01-01"",
                    ""checkout"": ""2019-01-01""
                },
                ""additionalneeds"": ""Breakfast""
            }");


            string expectedJsonString = expectedJson.ToString(Formatting.None);

            string responseJsonString = JObject.FromObject(responseObject.booking).ToString(Formatting.None);

            Assert.AreEqual(expectedJsonString, responseJsonString);
        }
    }
}

