using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace BooksInLibrary.Models
{
    [Table(Name = "Authors")]
    internal class Author
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "FirstName")]
        public string Name { get; set; }

        [Column(Name = "LastName")]
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
