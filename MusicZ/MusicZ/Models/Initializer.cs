using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicZ.Models
{
    class Initializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            context.Stuff.Add(new Stuff()
            {
                Name = "Andry",
                Surename = "Saprigin",
                Phone = "0639830317",
                Password = "cormax25524",
                ProcentFromsale = 15
            });

            base.Seed(context);

            context.SaveChanges();
        }
    }
}
