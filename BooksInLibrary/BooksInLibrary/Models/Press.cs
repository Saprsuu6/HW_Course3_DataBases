using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInLibrary.Models
{

    [Table(Name = "Press")]
    internal class Press
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        public Press Clone()
        {
            return new Press()
            {
                Id = Id,
                Name = Name,
            };
        }
    }
}
