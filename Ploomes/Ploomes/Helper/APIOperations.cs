using Newtonsoft.Json;
using Ploomes.Entities;
using System;
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
            return Post("/Contacts?$select=Id", contacts, "criar o cliente.");
        }

        public async Task<object> CreateDeals(Deals deals)
        {
            return Post("/Deals?$select=Id", deals, "criar a negociação.");
        }

        public async Task<object> CreateTasks(Tasks tasks)
        {
            return Post("/Tasks?#select=Id", tasks, "criar a tarefa.");
        }

        public async Task<object> UpdateDeals(Deals dealsUpdate, int id)
        {
            return Patch($"/Deals({id})?#select=Id", dealsUpdate, "atualizar a negociação.");
        }

        public async Task<object> FinishTasks(Tasks tasks, int id)
        {
            return Post($"/Tasks({id})/Finish?#select=Id", tasks, "finalizar a tarefa.");
        }

        public async Task<object> WinDeals(Deals deals, int id)
        {
            return Post($"/Deals({id})/Win?$select=Id", deals, "registrar a negociação");
        }

        public async Task<object> InteractionRecords(InteractionsRecords interactionsRecords)
        {
            return Post("/InteractionsRecords?$select=Id", interactionsRecords, "escrever no histórico.");
        }

        public async Task<object> Patch(string requestUri, object value, string message)
        {
            try
            {
                HttpClient client = _api.Initial();

                var jsonContent = JsonConvert.SerializeObject(value);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PatchAsync(requestUri, contentString);
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject(res);
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao {message}");
                return null;
            }
        }

        public async Task<object> Post(string requestUri, object value, string message)
        {
            try
            {
                HttpClient client = _api.Initial();

                var jsonContent = JsonConvert.SerializeObject(value);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(requestUri, contentString);

                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject(res);
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao {message}");
                return null;
            }
        }
    }
}
