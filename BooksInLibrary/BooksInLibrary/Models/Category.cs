using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace BooksInLibrary.Models
{
    [Table(Name = "Categories")]
    internal class Category
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        public Category Clone()
        {
            return new Category()
            {
                Id = Id,
                Name = Name,
            };
        }
    }
}
