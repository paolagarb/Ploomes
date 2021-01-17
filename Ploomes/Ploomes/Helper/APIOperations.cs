using Newtonsoft.Json;
using Ploomes.Entities;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ploomes.Helper
{
    public class APIOperations
    {
        PloomesAPI _api = new PloomesAPI();

        public async Task<object> CreateContact(Contacts contacts)
        {
            HttpClient client = _api.Initial();

            var jsonContent = JsonConvert.SerializeObject(contacts);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/Contacts?$select=Id", contentString);
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject(res);
            }
            return null;
        }

        public async Task<object> CreateDeals(Deals deals)
        {
            HttpClient client = _api.Initial();

            var jsonContent = JsonConvert.SerializeObject(deals);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/Deals?$select=Id", contentString);
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject(res);
            }
            return null;
        }

        public async Task<object> CreateTasks(Tasks tasks)
        {
            HttpClient client = _api.Initial();

            var jsonContent = JsonConvert.SerializeObject(tasks);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/Tasks?#select=Id", contentString);
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject(res);

            }
            return null;
        }

        public async Task<object> UpdateDeals(Deals dealsUpdate, int id)
        {
            HttpClient client = _api.Initial();

            var jsonContent = JsonConvert.SerializeObject(dealsUpdate);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PatchAsync($"/Deals({id})?#select=Id", contentString);
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject(res);
            }
            return null;
        }

        public async Task<object> FinishTasks(Tasks tasks, int id)
        {
            HttpClient client = _api.Initial();

            var jsonContent = JsonConvert.SerializeObject(tasks);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/Tasks({id})/Finish?#select=Id", contentString);
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject(res);
            }
            return null;
        }
        public async Task<object> WinDeals(Deals deals, int id)
        {
            HttpClient client = _api.Initial();

            var jsonContent = JsonConvert.SerializeObject(deals);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/Deals({id})/Win?$select=Id", contentString);
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject(res);
            }
            return null;
        }

        public async Task<object> InteractionRecords(InteractionsRecords interactionsRecords)
        {
            HttpClient client = _api.Initial();

            var jsonContent = JsonConvert.SerializeObject(interactionsRecords);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/InteractionsRecords?$select=Id", contentString);
            if (response.IsSuccessStatusCode)
            {
                var res = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject(res);

            }
            return null;
        }
    }
}
