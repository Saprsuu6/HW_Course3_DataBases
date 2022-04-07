using AutoMapper;
using BusinesLogic.Logic;
using BusinesLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ThreeModels.Models;

namespace ThreeModels.Controllers
{
    public class ShowQuestController : Controller
    {
        private readonly ILogger<ShowQuestController> _logger;

        public ShowQuestController(ILogger<ShowQuestController> logger)
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
        public IActionResult ShowQuest(string name)
        {
            GetSession();

            using (Quests workWithQuests = new Quests())
            {
                Mapper mapper =
                        new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MyQuest, Quest>()));

                Quest currentQuest =
                    mapper.Map<Quest>(workWithQuests.GetQuests().Find(item => item.Name == name));

                return View(currentQuest);
            }
        }
    }
}
