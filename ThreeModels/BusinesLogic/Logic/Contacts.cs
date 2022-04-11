using AutoMapper;
using BusinesLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithDB.Context;
using WorkWithDB.Models;

namespace BusinesLogic.Logic
{
    public class Contacts : IDisposable
    {
        private readonly WorkWithContacts workWithContext;
        private readonly Mapper mapperPhones;
        private readonly Mapper mapperOtherPhones;

        public Contacts()
        {
            DataBaseContext context = new DataBaseContext();
            WorkWithContacts workWithContext = new WorkWithContacts(context);

            this.workWithContext = new WorkWithContacts(context);

            var configPhones = new MapperConfiguration(cfg => cfg.CreateMap<MyPhone, Phone>());
            var configOtherPhones = new MapperConfiguration(cfg => cfg.CreateMap<Phone, MyPhone>());

            mapperPhones = new Mapper(configPhones);
            mapperOtherPhones = new Mapper(configOtherPhones);
        }
        public void CheckForExist(Contact contacts)
        {
            if (contacts == null)
                throw new ApplicationException("Contacts are empty.");

            try
            {
                workWithContext.GetContacts(contacts.Email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddContacts(MyContacts contacts)
        {
            var contact = new Contact()
            {
                Email = contacts.Email,
                CountryTownStreet = contacts.CountryTownStreet,
                Phones = mapperPhones.Map<List<Phone>>(contacts.Phones)
            };

            CheckForExist(contact);

            workWithContext.AddContacts(contact);
        }

        public void RemoveContacts(MyContacts contacts)
        {
            var contact = new Contact()
            {
                Id = contacts.Id,
                Email = contacts.Email,
                CountryTownStreet = contacts.CountryTownStreet,
                Phones = mapperPhones.Map<List<Phone>>(contacts.Phones)
            };

            workWithContext.RemoveContact(contact);
        }

        public MyContacts GetContacts(string email)
        {
            var contacts = workWithContext.GetContacts(email);

            MyContacts result = new MyContacts()
            {
                Id = contacts.Id,
                Email = contacts.Email,
                CountryTownStreet = contacts.CountryTownStreet,
                Phones = mapperOtherPhones.Map<List<MyPhone>>(contacts.Phones)
            };

            return result;
        }

        public void UpdateContacts(MyContacts contacts)
        {
            var contact = new Contact()
            {
                Id = contacts.Id,
                Email = contacts.Email,
                CountryTownStreet = contacts.CountryTownStreet,
                Phones = mapperPhones.Map<List<Phone>>(contacts.Phones)
            };

            workWithContext.UpdateContacts(contact);
        }

        public void Dispose()
        {
            workWithContext.Dispose();
        }
    }
}
