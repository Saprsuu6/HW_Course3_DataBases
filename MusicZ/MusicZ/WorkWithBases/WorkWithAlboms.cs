using MusicZ.Models;
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicZ.WorkWithBases
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
