﻿using Microsoft.AspNetCore.Mvc;
using NFLTeams.Models;

namespace NFLTeams.Controllers
{
    public class NameController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            var session = new NFLSession(HttpContext.Session);
            var model = new TeamListViewModel
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv(),
                Teams = session.GetMyTeams()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Change(TeamListViewModel model)
        {
            var session = new NFLSession(HttpContext.Session);
            session.SetUserName(model.UserName);
            return RedirectToAction("Index", "Home", new {
                    ActiveConf = session.GetActiveConf(),
                    ActiveDvi = session.GetActiveDiv()
                });
        }
    }
}
