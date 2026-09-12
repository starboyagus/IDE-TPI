using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;

namespace API.Clients
{
    public static class ApiClient
    {
        public static readonly HttpClient Http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5183/")
        };

        public static void SetAuthToken(string token)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public static void ClearAuthToken()
        {
            Http.DefaultRequestHeaders.Authorization = null;
        }
    }


}
