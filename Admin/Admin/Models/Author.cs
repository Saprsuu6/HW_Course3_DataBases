using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Models
{
    internal class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }

        public Author Clone()
        {
            return new Author()
            {
                Id = Id,
                Name = Name,
                Surename = Surename
            };
        }
    }
}
