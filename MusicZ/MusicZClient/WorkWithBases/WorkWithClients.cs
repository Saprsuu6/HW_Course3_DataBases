using MusicZClient.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicZClient.WorkWithBases
{
    internal class WorkWithClients
    {
        static public void AddClient(Context context, Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }

        static public void RemoveClient(Context context, Client client)
        {
            var clients = from concreteClient in context.Clients
                          where client.Id == concreteClient.Id
                          select concreteClient;

            Client newClient = clients.ToList()[0];

            context.Clients.Remove(newClient);
            context.SaveChanges();
        }

        static public void UpdateClient(Context context, Client client)
        {
            var clients = from concreteClient in context.Clients
                          where client.Name != concreteClient.Name
                          || concreteClient.Surename == client.Surename
                          || concreteClient.Phone == client.Phone
                          select concreteClient;

            Client newClient = clients.ToList()[0];
            newClient.Name = client.Name;
            newClient.Surename = client.Surename;
            newClient.Phone = client.Phone;
            newClient.Password = client.Password;
            newClient.Birthday = client.Birthday;

            context.SaveChanges();
        }

        static public Client GetClient(Context context, Client stuff)
        {
            var var = (from concreteStuff in context.Clients
                       where stuff.Phone == concreteStuff.Phone
                       && stuff.Password == concreteStuff.Password
                       && stuff.Name == concreteStuff.Name
                       && stuff.Surename == concreteStuff.Surename
                       select concreteStuff).ToList();

            return var[0];
        }

        static public List<Client> GetAllClients(Context context)
        {
            return context.Clients.ToList();
        }

        static public List<Client> GetClients(Context context, Client client)
        {
            return (from concreteClient in context.Clients
                    where concreteClient.Name == client.Name
                    || concreteClient.Surename == client.Surename
                    || concreteClient.Phone == client.Phone
                    || concreteClient.IsRegularClient == client.IsRegularClient
                    select concreteClient).ToList();
        }
    }
}
