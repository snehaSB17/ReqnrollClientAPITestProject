using RestSharp;

namespace ReqnrollClientAPITestProject.Models
{
    public class RestUtils
    {
        
        public static void InitialiseRestClient(string endpoint)
        {
            RestFactory.RestClient = new RestClient(endpoint);
            RestFactory.RestUtils = new RestUtils();
        }

        public static void InitialiseGetMethod()
        {
            RestFactory.RestRequest = new RestRequest(Method.GET);

        }

        public static void InitialisePostMethod()
        {
            RestFactory.RestRequest = new RestRequest(Method.POST);

        }

        public static void InitialisePutMethod()
        {
            RestFactory.RestRequest = new RestRequest(Method.PUT);

        }

        public static void InitialisePatchMethod()
        {
            RestFactory.RestRequest = new RestRequest(Method.PATCH);

        }

        public static void InitialiseDeleteMethod()
        {
            RestFactory.RestRequest = new RestRequest(Method.DELETE);

        }

        public static void AddJsonBody(string body)
        {
            
            RestFactory.RestRequest.AddJsonBody(body);
        }

    }
}
