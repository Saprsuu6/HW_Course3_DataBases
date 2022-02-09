using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Sailer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public string FullName { get { return Name + " " + Surename; } }
    }
}
