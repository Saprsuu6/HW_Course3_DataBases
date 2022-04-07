using Microsoft.AspNetCore.Mvc;
using ThreeModels.Models;
using BusinesLogic.Logic;
using BusinesLogic.Models;
using AutoMapper;
using System;
using System.Text;
using Microsoft.Extensions.Logging;

namespace ThreeModels.Controllers
{
    public class AutoRegController : Controller
    {
        private readonly ILogger<AutoRegController> _logger;

        public AutoRegController(ILogger<AutoRegController> logger)
        {
            _logger = logger;
            _logger.LogDebug("Debug message");
        }

        [HttpGet]
        public IActionResult AutorisationView()
        {
            return View("Autorisation");
        }

        [HttpGet]
        public IActionResult RegistrationView()
        {
            return View("Registration");
        }

        [HttpPost]
        public IActionResult Autorisation(Client client)
        {
            if (ModelState.IsValid)
            {
                client.Name = client.Name.Trim();
                client.Surename = client.Surename.Trim();
                client.Password = client.Password.Trim();

                Mapper mapper =
                    new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Client, MyClient>()));

                using (Clients workWithClients = new Clients())
                {
                    try
                    {
                        workWithClients.CheckForNotExist(mapper.Map<MyClient>(client));

                        string name = client.Name.ToLower();
                        byte[] bytes = Encoding.UTF8.GetBytes(name);
                        HttpContext.Session.Set("Name", bytes);

                        return Redirect("/Home/Index");
                    }
                    catch (Exception e)
                    {
                        ViewBag.Message = e.Message;
                        return View("Autorisation");
                    }
                }
            }
            else
            {
                ViewBag.Message = "Forms are not valid";
                return View("Autorisation");
            }
        }

        [HttpPost]
        public IActionResult Registration(Client client)
        {
            if (ModelState.IsValid
                && client.Name.ToLower() != "admin"
                && client.Surename.ToLower() != "admin"
                && client.Password.ToLower() != "admin")
            {
                client.Name = client.Name.Trim();
                client.Surename = client.Surename.Trim();
                client.Password = client.Password.Trim();

                Mapper mapper =
                    new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Client, MyClient>()));

                using (Clients workWithClients = new Clients())
                {
                    try
                    {
                        workWithClients.AddClient(mapper.Map<MyClient>(client));

                        string name = client.Name.ToLower();
                        byte[] bytes = Encoding.UTF8.GetBytes(name);
                        HttpContext.Session.Set("Name", bytes);

                        return Redirect("/Home/Index");
                    }
                    catch (Exception e)
                    {
                        ViewBag.Message = e.Message;
                        return View("Registration");
                    }
                }
            }
            else
            {
                ViewBag.Message = "Forms are not valid";
                return View("Autorisation");
            }
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Redirect("/Home/Index");
        }
    }
}
