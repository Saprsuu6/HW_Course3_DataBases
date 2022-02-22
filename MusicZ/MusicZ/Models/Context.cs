using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicZ.Models
{
    class Context : DbContext
    {
        public Context() : base("Music") { }

        static Context()
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<Albom> Alboms { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Stuff> Stuff { get; set; }
        public DbSet<Check> Checkes { get; set; }
    }
}
