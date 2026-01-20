using RestSharp;

namespace ReqnrollClientAPITestProject.Models
{
    public class RestUtils
    {
        private readonly string _baseUrl;

        public RestUtils(string baseUrl) 
        {
            if (string.IsNullOrWhiteSpace(baseUrl)) 
                throw new ArgumentException("Base URL cannot be null or empty", nameof(baseUrl)); 
            _baseUrl = baseUrl; 
        }
        public static void InitialiseRestClient(string endpoint)
        {
            var baseUrl = ConfigReader.GetBaseUrl();
            if (string.IsNullOrEmpty(baseUrl)) 
                throw new InvalidOperationException("Base URL is missing in configuration."); 
            var fullUrl = new Uri(new Uri(baseUrl.TrimEnd('/')), endpoint.TrimStart('/')); 
            RestFactory.RestClient = new RestClient(fullUrl); 
            RestFactory.RestUtils = new RestUtils(baseUrl);
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
