using AutoMapper;
using BusinesLogic.Models;
using System;
using System.Collections.Generic;
using WorkWithDB.Context;
using WorkWithDB.Models;

namespace BusinesLogic.Logic
{
    public class Clients : IDisposable
    {
        private readonly WorkWithClients workWithContext;
        private readonly Mapper mapper;
        private readonly Mapper mapperOther;

        public Clients()
        {
            DataBaseContext context = new DataBaseContext();
            WorkWithClients workWithContext = new WorkWithClients(context);

            this.workWithContext = new WorkWithClients(context);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MyClient, Client>());
            var configOther = new MapperConfiguration(cfg => cfg.CreateMap<Client, MyClient>());

            mapper = new Mapper(config);
            mapperOther = new Mapper(configOther);
        }

        public void CheckForNotExist(MyClient client)
        {
            if (client == null)
                throw new ApplicationException("Client is empty.");

            MyClient currentClient = mapperOther.Map<List<MyClient>>(workWithContext.GetClients()).
                Find(item => item.Name.ToLower() == client.Name.ToLower() 
                && item.Surename.ToLower() == client.Surename.ToLower());

            if (currentClient == null)
                throw new ApplicationException("Client is not exists. Try registration.");
        }

        private void CheckForExist(MyClient client)
        {
            if (client == null)
                throw new ApplicationException("Client is empty.");

            MyClient currentClient = mapperOther.Map<List<MyClient>>(workWithContext.GetClients()).
                Find(item => item.Name.ToLower() == client.Name.ToLower()
                && item.Surename.ToLower() == client.Surename.ToLower());

            if (currentClient != null)
                throw new ApplicationException("Client is aleready exists.");
        }
        
        public void AddClient(MyClient client)
        {
            CheckForExist(client);
            workWithContext.AddClient(mapper.Map<Client>(client));
        }

        public void RemoveClient(MyClient client)
        {
            workWithContext.RemoveClient(mapper.Map<Client>(client));
        }

        public List<MyClient> GetClients()
        {
            return mapperOther.Map<List<MyClient>>(workWithContext.GetClients());
        }

        public void UpdateClient(MyClient client)
        {
            workWithContext.UpdateClient(mapper.Map<Client>(client));
        }

        public void Dispose()
        {
            workWithContext.Dispose();
        }
    }
}
