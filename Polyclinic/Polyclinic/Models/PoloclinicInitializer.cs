using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.Models
{
    internal class PoloclinicInitializer : DropCreateDatabaseIfModelChanges<Polyclinic>
    {
        protected override void Seed(Polyclinic polyclinic)
        {
            polyclinic.Patients.Add(new Patient()
            {
                Name = "admin",
                Surename = "admin",
                Patronimic = "admin",
                Bithday = DateTime.Now.ToShortDateString(),
                Address = "admin"
            });
            polyclinic.SaveChanges();

            base.Seed(polyclinic);
        }
    }
}
