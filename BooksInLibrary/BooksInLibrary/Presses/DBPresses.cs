﻿using BooksInLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksInLibrary.Presses
{
    internal class DBPresses
    {
        private LibraryDataContext dataBase;

        public DBPresses()
        {
            dataBase = new LibraryDataContext();
        }

        public List<Press> GetAllPresses()
        {
            List<Press> presses = (from press in dataBase.Presses
                                    select press).ToList();

            if (presses.Count == 0)
                throw new ApplicationException("No authors");

            return presses;
        }

        public void AddPress(Press press)
        {
            if (press.Name == null || press.Name.Trim() == "")
                throw new ApplicationException("Fill presse's info.");

            try
            {
                dataBase.Presses.InsertOnSubmit(press);
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Press was not succesfully addaed. Try again");
            }
        }

        public void RemovePress(Press press)
        {
            if (press.Name == null || press.Name.Trim() == "")
                throw new ApplicationException("Please select press.");

            try
            {
                dataBase.Presses.DeleteOnSubmit(press);
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Press was not succesfully removed. Try again");
            }
        }

        public void UpdatePress(Press press)
        {
            if (press.Name == null || press.Name.Trim() == "")
                throw new ApplicationException("Please select press.");

            Press concretePress =
                dataBase.Presses.FirstOrDefault(temp => temp.Id == press.Id);

            concretePress = press;

            try
            {
                dataBase.SubmitChanges();
            }
            catch (Exception)
            {
                throw new ApplicationException("Press was not succesfully updated. Try again");
            }
        }

        public List<Press> FindPresses(Press press)
        {
            if (press.Name == null || press.Name.Trim() == "")
                throw new ApplicationException("Fill category's info.");

            List<Press> presses = (from concretePress in dataBase.Presses
                                    where concretePress.Name.Contains(press.Name)
                                    select concretePress).ToList();

            if (presses.Count == 0)
                throw new ApplicationException("No authors");

            return presses;
        }
    }
}
