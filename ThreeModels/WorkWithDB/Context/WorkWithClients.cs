using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkWithDB.Models;

namespace WorkWithDB.Context
{
    public class WorkWithClients : IDisposable
    {
        public WorkWithClients(DataBaseContext dataBaseContext)
        {
            context = dataBaseContext;
        }

        private readonly DataBaseContext context;

        public List<Client> GetClients()
        {
            return context.Clients.ToList();
        }

        public void AddClient(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }

        public void RemoveClient(Client client)
        {
            Client concreteClient = context.Clients.ToList().
                Find(item => item.Id == client.Id);

            if (concreteClient != null)
            {
                context.Clients.Remove(concreteClient);
                context.SaveChanges();
            }
        }

        public void UpdateClient(Client client)
        {
            var concreteClient = context.Clients.ToList().
                Find(item => item.Id == client.Id);

            if (concreteClient != null)
            {
                concreteClient.Name = client.Name;
                concreteClient.Surename = client.Surename;
                concreteClient.Password = client.Password;

                context.Update(concreteClient);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
