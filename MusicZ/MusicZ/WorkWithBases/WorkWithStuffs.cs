using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicZ.Models;

namespace MusicZ.WorkWithBases
{
    internal class WorkWithStuffs
    {
        static public void AddStuff(Context context, Stuff stuff)
        {
            context.Stuff.Add(stuff);
            context.SaveChanges();
        }

        static public void RemoveStuff(Context context, Stuff stuff)
        {
            context.Stuff.Remove(stuff);
            context.SaveChanges();
        }

        static public void UpdateStuff(Context context, Stuff stuff)
        {
            context.SaveChanges();
        }

        static public List<Stuff> GetAllStuff(Context context)
        {
            return context.Stuff.ToList();
        }

        static public List<Stuff> GetStuffs(Context context, Stuff stuff)
        {
            return (from concreteStuff in context.Stuff
                    where concreteStuff.Name == stuff.Name 
                    || concreteStuff.Surename == stuff.Surename
                    || concreteStuff.Phone == stuff.Phone
                    || concreteStuff.ProcentFromsale == stuff.ProcentFromsale
                    select concreteStuff).ToList();
        }
    }
}
