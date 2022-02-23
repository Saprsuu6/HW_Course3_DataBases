using MusicZ.Models;
using System.Collections.Generic;
using System.Linq;

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

        static public Stuff GetStuff(Context context, Stuff stuff)
        {
            var var = (from concreteStuff in context.Stuff
                       where stuff.Phone == concreteStuff.Phone
                       && stuff.Password == concreteStuff.Password
                       && stuff.Name == concreteStuff.Name
                       && stuff.Surename == concreteStuff.Surename
                       select concreteStuff).ToList();

            return var[0];
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
