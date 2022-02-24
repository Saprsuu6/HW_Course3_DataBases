using MusicZClient.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicZClient.WorkWithBases
{
    class WorkWithChecks
    {
        static public void AddCheck(Context context, Check check)
        {
            context.Checkes.Add(check);
            context.SaveChanges();
        }

        static public void RemoveCheck(Context context, Check check)
        {
            context.Checkes.Remove(check);
            context.SaveChanges();
        }

        static public void UpdateCheck(Context context, Check check)
        {
            context.SaveChanges();
        }

        static public List<Check> GetAllChecks(Context context)
        {
            return context.Checkes.ToList();
        }

        static public List<Check> GetClientChecks(Context context, Client client)
        {
            List<Check> cheks = (from concreteCheck in context.Checkes
                                 where concreteCheck.Id_Client.Id == client.Id
                                 select concreteCheck).ToList();

            return cheks;
        }

        static public List<Check> GetChecks(Context context, Check check)
        {
            return (from concreteCheck in context.Checkes
                    where concreteCheck.Id_Stuff.Id == check.Id_Stuff.Id
                    || concreteCheck.Id_Client.Id == check.Id_Client.Id
                    || concreteCheck.Id_Albom.Id == check.Id_Albom.Id
                    select concreteCheck).ToList();
        }
    }
}
