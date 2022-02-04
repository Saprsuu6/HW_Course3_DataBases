using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Models
{
    internal class Pres
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Pres Clone()
        {
            return new Pres()
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
