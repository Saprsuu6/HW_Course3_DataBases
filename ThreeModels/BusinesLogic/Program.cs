using System;
using BusinesLogic.Logic;
using AutoMapper;
using WorkWithDB.Context;
using BusinesLogic.Models;
using System.Collections.Generic;
using WorkWithDB.Models;

namespace BusinesLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contacts quests = new Contacts();

            //MyContacts contact = new MyContacts(
            //    "mr.asd.2002@list.ru",
            //    @"Ukrain\Youzne\Chimikov2");
            //
            //List<MyPhone> contacts = new List<MyPhone>()
            //{
            //    new MyPhone("123456789"),
            //    new MyPhone("123456789")
            //}; 
            //
            //contact.Phones = contacts;
            //
            //quests.AddContacts(contact);

            //quests.GetContacts("coffeei.2002@gmail.com");

            //MyContacts contact = new MyContacts(
            //    "mr.asdasd.2002@list.ru",
            //    @"Ukrain\Youzne\Chimikov2");
            //
            //List<MyPhone> contacts = new List<MyPhone>()
            //{
            //    new MyPhone("234234234"),
            //    new MyPhone("234234234")
            //}; 
            //
            //contact.Phones = contacts;
            //contact.Id = 5;
            //
            //quests.UpdateContacts(contact);

            //MyContacts contact = new MyContacts(
            //    "mr.asdasd.2002@list.ru",
            //    @"Ukrain\Youzne\Chimikov2");
            //
            //List<MyPhone> contacts = new List<MyPhone>()
            //{
            //    new MyPhone("234234234"),
            //    new MyPhone("234234234")
            //};
            //
            //contact.Phones = contacts;
            //contact.Id = 5;
            //
            //quests.RemoveContacts(contact);

            //MyQuest quest = new MyQuest(
            //    "Some quest",
            //    "data:image/jpeg;base64,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",
            //    1,
            //    50,
            //    "01:00",
            //    5);
            //quests.AddQuest(quest);

            //List<MyQuest> questsList = quests.GetQuests();
            //questsList[0].Name = "My new quest";
            //quests.UpdateQuest(questsList[0]);

            //List<MyQuest> questsList = quests.GetQuests();
            //quests.RemoveQuest(questsList[0]);

            //MyClient client = new MyClient("Kira", "Karpova", "Comrax25524");
            //clients.AddClient(client);

            //List<MyClient> clients2 = clients.GetClients();
            //clients2[0].Password = "Cormax12345";

            //clients.UpdateClient(clients2[0]);

            //List<MyClient> clients2 = clients.GetClients();
            //clients.RemoveClient(clients2[0]);
        }
    }
}
