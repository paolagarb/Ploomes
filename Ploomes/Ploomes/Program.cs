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

            try
            {
                Contacts contacts = new Contacts()
                {
                    Name = "Name Z",
                    Neighborhoood = "Pinheiros",
                    ZipCode = 0100,
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


                var contactsApi = api.CreateContact(contacts).Result; // 1. Criar um cliente
                var contactsId = contactsApi.value[0].Id;


                Deals deals = new Deals()
                {
                    Title = "Deals X",
                    ContactId = contactsId,
                    Amount = 12000,
                    StageId = 1
                };

                Tasks tasks = new Tasks()
                {
                    Title = "Tasks X",
                    Description = "Tasks description..",
                    DateTime = DateTime.Today,
                    ContactId = contactsId,
                };

                Deals dealsUpdate = new Deals()
                {
                    Title = "Deals X",
                    ContactId = contactsId,
                    Amount = 15000,
                    StageId = 1
                };

                InteractionRecords interactionRecords = new InteractionRecords()
                {
                    ContactId = contactsId,
                    Message = "Negócio fechado!"
                };

                var dealsApi = api.CreateDeals(deals).Result;// 2. Criar uma negociação com este cliente
                var dealsId = dealsApi.value[0].Id;

                var tasksApi = api.CreateTasks(tasks).Result; // 3. Criar uma tarefa dentro desta negociação
                var tasksId = tasksApi.value[0].Id;

                api.UpdateDeals(dealsUpdate, dealsId); // 4. Atualizar a negociação e atribuir o valor de R$ 15.000,00
                api.FinishTasks(tasks, tasksId); // 5. Finalizar a tarefa
                api.WinDeals(deals, dealsId); // 6. Ganhar a negociação

                var interactionRecordsApi = api.InteractionRecords(interactionRecords).Result; // 7.Escrever no histórico do cliente "Negócio fechado!"
                var interactionRecordsId = interactionRecordsApi.value[0].Id;

                Console.WriteLine($"\nContacts ID:  {contactsId}\n" +
                                  $"Deals ID:  {dealsId}\n" +
                                  $"Tasks ID:  {tasksId}\n" +
                                  $"Interactions Records ID:  {interactionRecordsId}");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro durante a execução.");
            }
        }
    }
}
