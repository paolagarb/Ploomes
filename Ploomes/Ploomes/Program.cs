using Ploomes.Entities;
using Ploomes.Helper;
using System;

namespace Ploomes
{
    class Program
    {
        static void Main(string[] args)
        {
            APIOperations api = new APIOperations();

            Contacts contacts = new Contacts()
            {
                Name = "Name X",
                Neighborhoood = "Pinheiros",
                ZipCode = 0000100,
                OriginId = 1,
                CompanyId = 1,
                StreetAddressNumber = "137",
                TypeId = 1,
                Phones = new Phones
                {
                    PhoneNumber = "40044004",
                    TypeId = 1,
                    CountryId = 1
                }
            };

            var contacstId = api.CreateContact(contacts); // 1. Criar um cliente

            Deals deals = new Deals()
            {
                Title = "Deals X",
                ContactId = contacstId.Id,
                Amount = 12000,
                StageId = 1
            };

            Tasks tasks = new Tasks()
            {
                Title = "Tasks X",
                Description = "Tasks description..",
                DateTime = DateTime.Today,
                ContactId = contacstId.Id,
            };

            Deals dealsUpdate = new Deals()
            {
                Title = "Deals X",
                ContactId = contacstId.Id,
                Amount = 15000,
                StageId = 1
            };

            InteractionsRecords interactionsRecords = new InteractionsRecords()
            {
                ContactId = contacstId.Id,
                Message = "Negócio fechado!"
            };

            var dealsId = api.CreateDeals(deals); // 2. Criar uma negociação com este cliente
            var tasksId = api.CreateTasks(tasks); // 3. Criar uma tarefa dentro desta negociação
            var dealsUpdateId = api.UpdateDeals(dealsUpdate, dealsId.Id); // 4. Atualizar a negociação e atribuir o valor de R$ 15.000,00
            var finishTask = api.FinishTasks(tasks, tasksId.Id); // 5. Finalizar a tarefa
            var winDeals = api.WinDeals(deals, dealsId.Id); // 6. Ganhar a negociação
            var interactionsRecordsId = api.InteractionRecords(interactionsRecords); // 7.Escrever no histórico do cliente "Negócio fechado!"

            Console.WriteLine($"\nContactsId:  {contacstId.Id}\n" +
                              $"Deals ID:  {dealsId.Id}\n" +
                              $"Tasks ID:  {tasksId.Id}\n" +
                              $"InteractionsRecords ID:  {interactionsRecordsId.Id}");
            Console.ReadLine();
        }
    }
}
