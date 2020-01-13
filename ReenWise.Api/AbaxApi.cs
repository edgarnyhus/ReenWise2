using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace ReenWise.Api
{
    public class AbaxApi
    {
        public static Object api_response;
        public static async Task GetApi(string token, string p)
        {
            try
            {
                var client = new RestClient("https://api-test.abax.cloud/v1/" + p);

                var authentication = new JwtAuthenticator(token);
                client.Authenticator = authentication;

                var request = new RestRequest(Method.GET);
                var response = client.Execute(request);
                api_response = JsonConvert.DeserializeObject<Object>(response.Content);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
