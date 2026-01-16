using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using Reqnroll;
using ReqnrollClientAPITestProject.Models;
using ReqnrollClientAPITestProject.Utilities;
using System.Net;

namespace ReqnrollClientAPITestProject.StepDefinitions
{
    [Binding]
    public class TestApiStepDefinitions
    {
        
        private readonly FeatureContext _featureContext;

        public TestApiStepDefinitions(FeatureContext featureContext)
        {
            _featureContext = featureContext;

        }

        [Given("I constructs {string} for {string}")]
        public void GivenIConstructsFor(string httpMethod, string endpoint)
        {
            if (endpoint.Contains("{id}") && _featureContext.ContainsKey("id"))
            { 
                var id = _featureContext["id"].ToString(); 
                endpoint = endpoint.Replace("{id}", id);
            }

            RestUtils.InitialiseRestClient("https://api.restful-api.dev/" + endpoint);

            switch (httpMethod)
            {
                case "GET":
                    RestUtils.InitialiseGetMethod();
                    break;
                case "POST":
                    RestUtils.InitialisePostMethod();
                    break;
                case "PUT":
                    RestUtils.InitialisePutMethod();
                    break;
                case "PATCH":
                    RestUtils.InitialisePatchMethod();
                    break;
                case "DELETE":
                    RestUtils.InitialiseDeleteMethod();
                    break;
                default:
                    break;

            }
        }

        [When("I pass the request body")]
        public void WhenIPassTheRequestBody()
        {
            string json = JsonConvert.SerializeObject(TestData.ValidData());
            RestUtils.AddJsonBody(json);
        }

        [When("I update the request body")]
        public void WhenIUpdateTheRequestBody()
        {
            string json = JsonConvert.SerializeObject(TestData.PutData());
            RestUtils.AddJsonBody(json);
        }

        [When("I update partially the request body")]
        public void WhenIUpdatePartiallyTheRequestBody()
        {
            string json = JsonConvert.SerializeObject(TestData.PatchData());
            RestUtils.AddJsonBody(json);
        }


        [When("I submit the request")]
        public void WhenISubmitTheRequest()
        {
            RestFactory.RestResponse = RestFactory.RestClient.Execute(RestFactory.RestRequest);
      
            if (RestFactory.RestResponse.Content.TrimStart().StartsWith("[")) 
            { 
                var list = JsonConvert.DeserializeObject<List<Objects>>(RestFactory.RestResponse.Content); 
                _featureContext["id"] = list.First().id; 
            }
            else
            { 
                var obj = JsonConvert.DeserializeObject<Objects>(RestFactory.RestResponse.Content);
                _featureContext["id"] = obj.id;
            }
        }

        [Then("I expect Statuscode to be {string}")]
        public static void ThenIExpectStatuscodeToBe(HttpStatusCode ResponceStatusCode)
        {
            var status = RestFactory.RestResponse.StatusCode;
            status.Should().Be(ResponceStatusCode);
        }

        [Then("the response should contain objects with ids {string}, {string}, and {string}")]
        public void ThenTheResponseShouldContainObjectsWithIdsAnd(string id1, string id2, string id3)
        {
            var data = JsonConvert.DeserializeObject<List<Objects>>(RestFactory.RestResponse.Content); 
            data.Select(o => o.id).Should().Contain(new[] { id1, id2, id3 });
        }

        [Then("I expect responce message")]
        public void ThenIExpectResponceMessage(string verifyMessage)
        {
            string statusMessage = RestFactory.RestResponse.Content;
            string message = verifyMessage.Replace("{id}", RestFactory.RestResponse.ResponseUri.Segments[2]);
            Assert.That(message.Trim(), Is.EqualTo(statusMessage));
        }


    }
}
