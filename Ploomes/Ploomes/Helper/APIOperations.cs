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
        HttpClient client;

        public APIOperations()
        {
            client = PloomesAPI.Initial();
        }

        public dynamic CreateContact(Contacts contacts)
        {
            return Post("Contacts?$select=Id", contacts, "criar o cliente.");
        }

        public dynamic CreateDeals(Deals deals)
        {
            return Post("Deals?$select=Id", deals, "criar a negociação.");
        }

        public dynamic CreateTasks(Tasks tasks)
        {
            return Post("Tasks?$select=Id", tasks, "criar a tarefa.");
        }

        public dynamic UpdateDeals(Deals dealsUpdate, int id)
        {
            return Patch($"Deals({id})", dealsUpdate, "atualizar a negociação.");
        }

        public dynamic FinishTasks(Tasks tasks, int id)
        {
            return Post($"Tasks({id})/Finish", tasks, "finalizar a tarefa.");
        }

        public dynamic WinDeals(Deals deals, int id)
        {
            return Post($"Deals({id})/Win", deals, "registrar a negociação");
        }

        public dynamic InteractionRecords(InteractionRecords interactionRecords)
        {
            return Post("InteractionRecords?$select=Id", interactionRecords, "escrever no histórico.");
        }

        public async Task<dynamic> Patch(string requestUri, object value, string message)
        {
            try
            {
                var jsonContent = JsonConvert.SerializeObject(value);
                var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await client.PatchAsync(requestUri, contentString);

                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<dynamic>(res);
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao {message}");
                return 0;
            }
        }

        public async Task<dynamic> Post(string requestUri, object value, string message)
        {
            try
            {
                var response = await client.PostAsJsonAsync(requestUri, value);

                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<dynamic>(res);
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao {message}");
                return 0;
            }
        }
    }
}
