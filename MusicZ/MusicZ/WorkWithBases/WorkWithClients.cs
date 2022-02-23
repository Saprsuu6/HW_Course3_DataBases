using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicZ.Models;

namespace MusicZ.WorkWithBases
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
            context.Clients.Remove(client);
            context.SaveChanges();
        }

        static public void UpdateClient(Context context, Client client)
        {
            context.SaveChanges();
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
                    || concreteClient.Birthday == client.Birthday
                    select concreteClient).ToList();
        }
    }
}
