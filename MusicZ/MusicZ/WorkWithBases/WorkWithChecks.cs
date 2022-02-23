using MusicZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicZ.WorkWithBases
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

        static public List<Check> GetChecks(Context context, Check check)
        {
            return (from concreteCheck in context.Checkes
                    where concreteCheck.Id_Stuff == check.Id_Stuff
                    || concreteCheck.Id_Client == check.Id_Client
                    || concreteCheck.Id_Albom == check.Id_Albom
                    select concreteCheck).ToList();
        }
    }
}
