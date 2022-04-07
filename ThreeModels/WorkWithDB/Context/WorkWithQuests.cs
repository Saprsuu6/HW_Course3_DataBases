using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithDB.Models;

namespace WorkWithDB.Context
{
    public class WorkWithQuests : IDisposable
    {
        public WorkWithQuests(DataBaseContext dataBaseContext)
        {
            context = dataBaseContext;
        }

        private readonly DataBaseContext context;

        public List<Quest> GetQuests()
        {
            return context.Quests.ToList();
        }

        public void AddQuest(Quest quest)
        {
            context.Quests.Add(quest);
            context.SaveChanges();
        }

        public void RemoveQuest(Quest quest)
        {
            Quest concreteQuest = context.Quests.ToList().
                Find(item => item.Id == quest.Id);

            if (concreteQuest != null)
            {
                context.Quests.Remove(concreteQuest);
                context.SaveChanges();
            }
        }

        public void UpdateQuest(Quest quest)
        {
            var concreteQuest = context.Quests.ToList().
                Find(item => item.Id == quest.Id);

            if (concreteQuest != null)
            {
                concreteQuest.Name = quest.Name;
                concreteQuest.Photo = quest.Photo;
                concreteQuest.MinPalyers = quest.MinPalyers;
                concreteQuest.MaxPalyers = quest.MaxPalyers;
                concreteQuest.Time = quest.Time;
                concreteQuest.Rating = quest.Rating;

                context.Update(concreteQuest);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
