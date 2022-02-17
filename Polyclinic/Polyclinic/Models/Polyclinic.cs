using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyclinic.Models
{
    internal class Polyclinic : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        static Polyclinic()
        {
            Database.SetInitializer(new PoloclinicInitializer());
        }
    }
}
