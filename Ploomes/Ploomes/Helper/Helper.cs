using System;
using System.Net.Http;

namespace Ploomes.Helper
{
    public class PloomesAPI
    {
        public HttpClient Initial()
        {
            var uk = ""; //Add User-Key

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api2.ploomes.com");
            client.DefaultRequestHeaders.Add("User-Key", uk);
            return client;

        }
    }
}
