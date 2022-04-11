using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithDB.Models;

namespace WorkWithDB.Context
{
    public class WorkWithContacts : IDisposable
    {
        public WorkWithContacts(DataBaseContext dataBaseContext)
        {
            context = dataBaseContext;
        }

        private readonly DataBaseContext context;

        public void UpdateContacts(Contact contact)
        {
            var concreteContact = context.Contacts.ToList().
                Find(item => item.Id == contact.Id);

            concreteContact.Phones = context.Phones.ToList()
                .FindAll(item => item.Contact.Id == contact.Id);

            if (concreteContact != null)
            {
                concreteContact.Email = contact.Email;
                concreteContact.CountryTownStreet = contact.CountryTownStreet;
                concreteContact.Phones = contact.Phones;

                context.Update(concreteContact);
                context.SaveChanges();
            }
        }

        public void AddContacts(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
        }

        public void RemoveContact(Contact contact)
        {
            Contact concreteContact = context.Contacts.ToList().
                Find(item => item.Id == contact.Id);

            if (concreteContact != null)
            { 
                context.Contacts.Remove(concreteContact);
                context.SaveChanges();
            }
        }

        public Contact GetContacts(string email)
        {
            Contact contact = context.Contacts.ToList().
                Find(item => item.Email.ToLower() == email.ToLower());

            if (contact == null)
                throw new ApplicationException("Contacts are not aleready exists.");

            contact.Phones = context.Phones.ToList()
                .FindAll(item => item.Contact.Id == contact.Id);

            return contact;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
