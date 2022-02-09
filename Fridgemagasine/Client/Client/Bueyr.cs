using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Bueyr
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public int Id_Fridge { get; set; }

        public Bueyr Clone()
        {
            return new Bueyr()
            {
                Id = Id,
                Name = Name,
                Surename = Surename,
                Id_Fridge = Id_Fridge
            };
        }
    }
}
