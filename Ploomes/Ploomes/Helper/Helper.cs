using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Ploomes.Helper
{
    public class PloomesAPI
    {
        public static HttpClient Initial()
        {
            var uk = ""; //Add User-Key

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api2.ploomes.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Key", uk);

            return client;
        }
    }
}
