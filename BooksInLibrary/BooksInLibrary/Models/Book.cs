using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace BooksInLibrary.Models
{
    [Table(Name = "Books")]
    internal class Book
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(Name = "Name")]
        public string Name { get; set; }

        [Column(Name = "Pages")]
        public int Pages { get; set; }

        [Column(Name = "YearPress")]
        public int YearPress { get; set; }
        
        [Column(Name = "Id_Themes")]
        public int IdTheme { get; set; }

        [Column(Name = "Id_Category")]
        public int IdCategory { get; set; }

        [Column(Name = "Id_Author")]
        public int IdAuthor { get; set; }

        [Column(Name = "Id_Press")]
        public int IdPress { get; set; }

        [Column(Name = "Comment")]
        public string Comment { get; set; }

        [Column(Name = "Quantity")]
        public int Quantity { get; set; }


        private EntityRef<Theme> theme;

        [Association(Storage = "theme", ThisKey = "IdTheme")]
        public Theme Theme
        {
            get { return theme.Entity; }
            set { theme.Entity = value; }
        }

        private EntityRef<Category> category;

        [Association(Storage = "category", ThisKey = "IdCategory")]
        public Category Category
        {
            get { return category.Entity; }
            set { category.Entity = value; }
        }

        private EntityRef<Author> author;

        [Association(Storage = "author", ThisKey = "IdAuthor")]
        public Author Author
        {
            get { return author.Entity; }
            set { author.Entity = value; }
        }

        private EntityRef<Press> press;

        [Association(Storage = "press", ThisKey = "IdPress")]
        public Press Press
        {
            get { return press.Entity; }
            set { press.Entity = value; }
        }

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
