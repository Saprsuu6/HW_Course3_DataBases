using AutoMapper;
using BusinesLogic.Logic;
using BusinesLogic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;
using ThreeModels.Models;

namespace ThreeModels.Controllers
{
    public class WorkWithQuestController : Controller
    {
        private readonly ILogger<WorkWithQuestController> _logger;

        public WorkWithQuestController(ILogger<WorkWithQuestController> logger)
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
        public IActionResult CreateView()
        {
            GetSession();
            return View("CreateQuest");
        }

        [HttpGet]
        public IActionResult RemoveView(string name)
        {
            GetSession();

            Mapper mapper =
                new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MyQuest, Quest>()));
            Quest quest;

            using (Quests workWithQuests = new Quests())
            {
                quest = mapper.Map<Quest>(workWithQuests.GetQuests().Find(item => item.Name == name));
            }

            return View("RemoveQuest", quest);
        }

        [HttpGet]
        public IActionResult UpdateView(string name)
        {
            GetSession();

            Mapper mapper =
                new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<MyQuest, Quest>()));
            Quest quest;

            using (Quests workWithQuests = new Quests())
            {
                quest = mapper.Map<Quest>(workWithQuests.GetQuests().Find(item => item.Name == name));
            }

            return View("UpdateQuest", quest);
        }

        [HttpPost]
        public IActionResult Create(Quest quest)
        {
            if (ModelState.IsValid)
            {
                using (Quests workWithQuests = new Quests())
                {
                    Mapper mapper =
                        new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Quest, MyQuest>()));

                    try
                    {
                        workWithQuests.AddQuest(mapper.Map<MyQuest>(quest));

                        ViewBag.Message = "Quest was sucesfullty added.";
                        return View("CreateQuest");
                    }
                    catch (Exception e)
                    {
                        ViewBag.Message = e.Message;
                        return View("CreateQuest");
                    }
                }
            }
            else
            {
                ViewBag.Message = "Fields are not valid.";
                return View("CreateQuest");
            }
        }

        [HttpPost]
        public IActionResult Remove(Quest quest)
        {
            using (Quests workWithQuests = new Quests())
            {
                Mapper mapper =
                    new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Quest, MyQuest>()));

                workWithQuests.RemoveQuest(mapper.Map<MyQuest>(quest));
                return Redirect("/Home/Index");
            }
        }

        [HttpPost]
        public IActionResult Update(Quest quest)
        {
            if (ModelState.IsValid)
            {
                using (Quests workWithQuests = new Quests())
                {
                    Mapper mapper =
                        new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Quest, MyQuest>()));

                    workWithQuests.UpdateQuest(mapper.Map<MyQuest>(quest));
                    return Redirect("/Home/Index");
                }
            }
            else
            {
                if (CultureInfo.CurrentCulture.Name == "en")
                    ViewBag.Message = "Fields are not valid.";
                else if (CultureInfo.CurrentCulture.Name == "ru")
                    ViewBag.Message = "Поля не валидные.";
                
                return View("UpdateQuest");
            }
        }
    }
}
