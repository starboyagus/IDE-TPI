using System;
using System.Net.Http;

namespace WindowsForm
{
    public static class ApiClient
    {
        public static readonly HttpClient Http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5183/")
        };
    }
}
