using AutoMapper;
using BusinesLogic.Models;
using System;
using System.Collections.Generic;
using WorkWithDB.Context;
using WorkWithDB.Models;

namespace BusinesLogic.Logic
{
    public class Quests : IDisposable
    {
        private readonly WorkWithQuests workWithContext;
        private readonly Mapper mapper;
        private readonly Mapper mapperOther;

        public Quests()
        {
            DataBaseContext context = new DataBaseContext();
            WorkWithClients workWithContext = new WorkWithClients(context);

            this.workWithContext = new WorkWithQuests(context);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<MyQuest, Quest>());
            var configOther = new MapperConfiguration(cfg => cfg.CreateMap<Quest, MyQuest>());

            mapper = new Mapper(config);
            mapperOther = new Mapper(configOther);
        }

        private void CheckForExist(MyQuest quest)
        {
            if (quest == null)
                throw new ApplicationException("Quest is empty.");

            MyQuest currentQuest = mapperOther.Map<List<MyQuest>>(workWithContext.GetQuests()).
                Find(item => item.Name.ToLower() == quest.Name.ToLower());

            if (currentQuest != null)
                throw new ApplicationException("Quest is aleready exists.");
        }

        public void AddQuest(MyQuest quest)
        {
            CheckForExist(quest);
            workWithContext.AddQuest(mapper.Map<Quest>(quest));
        }

        public void RemoveQuest(MyQuest quest)
        {
            workWithContext.RemoveQuest(mapper.Map<Quest>(quest));
        }
        
        public List<MyQuest> GetQuests()
        {
            return mapperOther.Map<List<MyQuest>>(workWithContext.GetQuests());
        }

        public void UpdateQuest(MyQuest quest)
        {
            workWithContext.UpdateQuest(mapper.Map<Quest>(quest));
        }

        public void Dispose()
        {
            workWithContext.Dispose();
        }
    }
}
