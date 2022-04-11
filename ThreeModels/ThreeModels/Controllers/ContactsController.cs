using BusinesLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using BusinesLogic.Models;
using ThreeModels.Models;
using System.Collections.Generic;

namespace ThreeModels.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ILogger<ContactsController> _logger;
        private const string email = "coffeei.2002@gmail.com";

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
            _logger.LogDebug("Debug message");
        }

        private void GetSession()
        {
            byte[] data;
            string result;

            HttpContext.Session.TryGetValue("Name", out data);

            if (data != null)
            {
                result = System.Text.Encoding.UTF8.GetString(data);
                ViewBag.Session = result;
            }
        }

        public IActionResult ShowContacts()
        {
            GetSession();

            Mapper mapper = 
                new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MyPhone, Phone>()));

            using (BusinesLogic.Logic.Contacts workWithContacts = new BusinesLogic.Logic.Contacts())
            {
                var contacts = workWithContacts.GetContacts(email);

                Models.Contacts result = new Models.Contacts()
                {
                    Id = contacts.Id,
                    Email = contacts.Email,
                    CountryTownStreet = contacts.CountryTownStreet,
                    Phones = mapper.Map<List<Phone>>(contacts.Phones)
                };

                return View(result);
            }  
        }
    }
}
