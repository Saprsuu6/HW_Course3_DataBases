using MusicZClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicZClient.WorkWithBases
{
    class WorkWithAlboms
    {
        static public void AddAlbom(Context context, Albom albom)
        {
            context.Alboms.Add(albom);
            context.SaveChanges();
        }

        static public void RemoveAlbom(Context context, Albom albom)
        {
            context.Alboms.Remove(albom);
            context.SaveChanges();
        }

        static public void UpdateAlbom(Context context, Albom albom)
        {
            context.SaveChanges();
        }

        static public List<Albom> GetAllAlboms(Context context)
        {
            return context.Alboms.ToList();
        }

        static public List<Albom> GetNews(Context context)
        {
            return (from concreteAlbom in context.Alboms
                    where concreteAlbom.YearOfAdding.Month >= DateTime.Now.Month - 1
                    select concreteAlbom).ToList();
        }

        static public List<Albom> PopularAlboms(Context context, string condition)
        {
            List<Albom> alboms = GetAllAlboms(context);
            List<Check> checks = WorkWithChecks.GetAllChecks(context);

            if (condition == "year")
                checks = checks.FindAll(check => check.Date.Year >= DateTime.Now.Year - 1);
            else if (condition == "month")
                checks = checks.FindAll(check => check.Date.Month >= DateTime.Now.Month - 1);
            else if (condition == "week")
                checks = checks.FindAll(check => check.Date.DayOfWeek >= DateTime.Now.DayOfWeek - 7);

            SortedList<int, string> pair = new SortedList<int, string>();

            foreach (Albom item in alboms)
            {
                int counter = 0;

                foreach (Check check in checks)
                {
                    if (item.Id == check.Id_Albom.Id)
                        counter += check.AmountAlboms;
                }

                pair.Add(counter, item.Name);
            }

            int max = 0;
            for (int i = 0; i < pair.Count - 1; i++)
                max = Math.Max(pair.Keys[i], pair.Keys[i + 1]);

            string name = pair[max];

            return (from concreteAlbom in context.Alboms
                   where concreteAlbom.Name == name
                    select concreteAlbom).ToList();
        }


        static public List<Albom> FindAlboms(Context context, Albom albom)
        {
            return (from concreteAlbom in context.Alboms
                    where concreteAlbom.Name == albom.Name
                    || concreteAlbom.BandName == albom.BandName
                    || concreteAlbom.Genre == albom.Genre
                    select concreteAlbom).ToList();
        }

        static public List<Albom> GetAlboms(Context context, Albom albom)
        {
            return (from concreteAlbom in context.Alboms
                    where concreteAlbom.Name == albom.Name
                    || concreteAlbom.BandName == albom.BandName
                    || concreteAlbom.Publisher == albom.Publisher
                    || concreteAlbom.AmountTracks == albom.AmountTracks
                    || concreteAlbom.Genre == albom.Genre
                    || concreteAlbom.YearOfPublish == albom.YearOfPublish
                    || concreteAlbom.YearOfAdding == albom.YearOfAdding
                    || concreteAlbom.CostPrice == albom.CostPrice
                    || concreteAlbom.PriceForSale == albom.PriceForSale
                    || concreteAlbom.Discount == albom.Discount
                    || concreteAlbom.ReservedByClient == albom.ReservedByClient
                    select concreteAlbom).ToList();
        }
    }
}
