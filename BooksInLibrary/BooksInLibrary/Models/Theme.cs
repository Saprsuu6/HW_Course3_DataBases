using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace BooksInLibrary.Models
{
    [Table(Name = "Themes")]
    internal class Theme
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        public Theme Clone()
        {
            return new Theme()
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
