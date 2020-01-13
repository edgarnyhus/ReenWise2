using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace ReenWise.Api
{
    public class AccessToken
    {
        public static string GetToken(string clientId, string clientSecret)
        {
            var client = new RestClient("https://identity.abax.cloud/connect/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded",
                $"grant_type=client_credentials&client_id={clientId}&client_secret={clientSecret}&audience=https://identity.abax.cloud/connect/token",
                ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            var accessToken = JsonConvert.DeserializeObject<Token>(response.Content);
            return accessToken.access_token;

        }
        public class Token
        {
            public string access_token { get; set; }
            public int expires_in { get; set; }
            public string token_type { get; set; }
            public string scope { get; set; }
        }

        public class ClientCredentials
        {
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }
        }
    }
}
