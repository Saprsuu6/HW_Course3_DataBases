using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Models;

namespace Books
{
    internal class AddToStart
    {
        public static void FillTables(Context context)
        {
            Author author1 = new Author() { Name = "Andry", Surename = "Saprigin" };
            Author author2 = new Author() { Name = "Kira", Surename = "Belocurova" };

            context.Authors.Add(author1);
            context.Authors.Add(author2);
            context.SaveChanges();

            Press press1 = new Press() { Name = "Press1" };
            Press press2 = new Press() { Name = "Press2" };

            context.Presses.Add(press1);
            context.Presses.Add(press2);
            context.SaveChanges();

            Category category1 = new Category() { Name = "category1" };
            Category category2 = new Category() { Name = "category2" };

            context.Categories.Add(category1);
            context.Categories.Add(category2);
            context.SaveChanges();

            Theme theme1 = new Theme() { Name = "theme1" };
            Theme theme2 = new Theme() { Name = "theme2" };

            context.Themes.Add(theme1);
            context.Themes.Add(theme2);
            context.SaveChanges();

            Book book = new Book()
            {
                Name = "Some book",
                Pages = 50,
                YearPress = 2002,
                Comment = "comment",
                Quantity = 1,
                Author = author1,
                Press = press1,
                Category = category1,  
                Theme = theme1
            };

            context.Books.Add(book);
            context.SaveChanges();
        }
    }
}
