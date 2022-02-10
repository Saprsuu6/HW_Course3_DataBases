using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInLibrary.Models
{
    internal class LibraryDataContext : DataContext
    {
        public LibraryDataContext()
            : base(ConfigurationManager.ConnectionStrings["Library"].ConnectionString)
        { }


        public Table<Book> Books => GetTable<Book>();
        public Table<Author> Authors => GetTable<Author>();
        public Table<Press> Presses => GetTable<Press>();
        public Table<Category> Categories => GetTable<Category>();
        public Table<Theme> Themes => GetTable<Theme>();
    }
}
