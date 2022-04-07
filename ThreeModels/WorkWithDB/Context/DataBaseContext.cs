using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithDB.Models;

namespace WorkWithDB.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Quest> Quests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB; Database=MyNewMagasine; Trusted_Connection=True;");
        }
    }
}
