using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Models
{
    internal class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public int YearPress { get; set; }
        public int IdTheme { get; set; }
        public int IdCategory { get; set; }
        public int IdAuthor { get; set; }
        public int IdPress { get; set; }
        public string Comment { get; set; }
        public int Quantity { get; set; }
        
        public Book Clone()
        {
            return new Book()
            {
                Id = Id,
                Name = Name,
                Pages = Pages,
                YearPress = YearPress,
                IdTheme = IdTheme,
                IdCategory = IdCategory,
                IdAuthor = IdAuthor,
                IdPress = IdPress,
                Comment = Comment,
                Quantity = Quantity
            };
        }
    }
}
