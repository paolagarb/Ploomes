using System;
using System.Net.Http;

namespace Ploomes.Helper
{
    public class PloomesAPI
    {
        public HttpClient Initial()
        {
            var uk = "6851A68D2C5BF9BEFA415CC9DF4973AFE9E08086899EC3714025CB8F0C88C36A4E6DED2BEC3270969A847D2269FF2BE253D984C3A02A29FF0FD2AF0E952A48C0";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api2.ploomes.com");
            client.DefaultRequestHeaders.Add("User-Key", uk);
            return client;

        }
    }
}
