using AutoMapper;
using BusinesLogic.Logic;
using BusinesLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text;
using ThreeModels.Models;

namespace ThreeModels.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
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

        [HttpGet]
        public IActionResult ShowAccount()
        {
            GetSession();

            using (Clients workWithClients = new Clients())
            {
                Mapper mapper =
                    new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MyClient, Client>()));

                Client client = mapper.Map<Client>(workWithClients.GetClients().Find(item => item.Name.ToLower() == ViewBag.Session));

                return View(client);
            }
        }

        [HttpGet]
        public IActionResult ShowAccountUpdate(Client client)
        {
            GetSession();

            using (Clients workWithClients = new Clients())
            {
                return View(client);
            }
        }

        [HttpPost]
        public IActionResult Remove(Client client)
        {
            using (Clients workWithClients = new Clients())
            {
                Mapper mapper =
                    new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Client, MyClient>()));

                workWithClients.RemoveClient(mapper.Map<MyClient>(client));

                HttpContext.Session.Clear();
                return Redirect("/Home/Index");
            }
        }

        public IActionResult Update(Client client)
        {
            client.Name = client.Name.Trim();
            client.Surename = client.Surename.Trim();
            client.Password = client.Password.Trim();

            using (Clients workWithClients = new Clients())
            {
                Mapper mapper =
                    new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Client, MyClient>()));

                workWithClients.UpdateClient(mapper.Map<MyClient>(client));

                string name = client.Name.ToLower();
                byte[] bytes = Encoding.UTF8.GetBytes(name);
                HttpContext.Session.Clear();
                HttpContext.Session.Set("Name", bytes);

                GetSession();

                ViewBag.Message = "Your account was duccesfully apdated.";
                return View("ShowAccountUpdate", client);
            }
        }
    }
}
