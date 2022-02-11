using BooksInLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInLibrary.Categories
{
    internal class DBCategories
    {
        private LibraryDataContext dataBase;

        public DBCategories()
        {
            dataBase = new LibraryDataContext();
        }

        public List<Category> GetAllCtegories()
        {
            List<Category> categories = (from category in dataBase.Categories
                                   select category).ToList();

            if (categories.Count == 0)
                throw new ApplicationException("No categories");

            return categories;
        }

        public void AddCategory(Category category)
        {
            if (category.Name == null || category.Name.Trim() == "")
                throw new ApplicationException("Fill categorie's info.");

            try
            {
                dataBase.Categories.InsertOnSubmit(category);
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Category was not succesfully addaed. Try again");
            }
        }

        private void RemoveBooksWithCategoryId(int id)
        {
            var books = (from book in dataBase.Books
                         where book.IdCategory == id
                         select book).ToList();

            try
            {
                foreach (Book book in books)
                    dataBase.Books.DeleteOnSubmit(book);

                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Book with this category was not succesfully removed. Try again");
            }
        }

        public void RemoveCategory(Category category)
        {
            if (category.Name == null || category.Name.Trim() == "")
                throw new ApplicationException("Please select category.");

            RemoveBooksWithCategoryId(category.Id);

            try
            {
                dataBase.Categories.DeleteOnSubmit(category);
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Category was not succesfully removed. Try again");
            }
        }

        public void UpdateCategory(Category category)
        {
            if (category.Name == null || category.Name.Trim() == "")
                throw new ApplicationException("Please select category.");

            Category concretePress =
                dataBase.Categories.FirstOrDefault(temp => temp.Id == category.Id);

            concretePress = category;

            try
            {
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Category was not succesfully updated. Try again");
            }
        }

        public List<Category> FindCategories(Category category)
        {
            if (category.Name == null || category.Name.Trim() == "")
                throw new ApplicationException("Fill categorie's info.");

            List<Category> categories = (from concreteCategory in dataBase.Categories
                                   where concreteCategory.Name.Contains(category.Name)
                                   select concreteCategory).ToList();

            if (categories.Count == 0)
                throw new ApplicationException("No categories");

            return categories;
        }
    }
}
