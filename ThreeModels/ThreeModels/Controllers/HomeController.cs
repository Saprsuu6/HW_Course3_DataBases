using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ThreeModels.Models;
using BusinesLogic.Logic;
using BusinesLogic.Models;
using AutoMapper;

namespace ThreeModels.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
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

        public IActionResult Index()
        {
            GetSession();

            using (Quests workWithQuests = new Quests())
            {
                if (workWithQuests.GetQuests().Count() != 0)
                {
                    Mapper mapper =
                        new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MyQuest, Quest>()));

                    IEnumerable<Quest> myQuests =
                        mapper.Map<List<MyQuest>, List<Quest>>(workWithQuests.GetQuests());

                    return View("QuestList", myQuests);
                }
                else
                    return View("QuestExeptionEmpty");
            }
        }

        public IActionResult Privacy()
        {
            GetSession();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
