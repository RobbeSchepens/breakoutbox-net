using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BreakOutBox.Models;
using BreakOutBox.Models.Domain;
using BreakOutBox.Filters;
using Microsoft.AspNetCore.Http;

namespace BreakOutBox.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISessieRepository _sessieRepository;

        public HomeController(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Error(int? statusCode = null)
        {
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            if (statusCode.HasValue)
            {
                if (statusCode == 404 || statusCode == 500)
                {
                    return View(statusCode.ToString());
                }
            }
            return View();
        }

        [HttpPost]
        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult Index(Sessie sessie, string sessiecode)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (sessie != null)
                    {
                        if (sessie.CurrentState is SessieNonActiefState == false)
                            return RedirectToAction(nameof(SessieController.GroepKiezen), "Sessie");
                        else
                            TempData["info"] = $"Deze sessie is niet geactiveerd.";
                    }
                    else
                        TempData["warning"] = $"Deze sessie werd niet gevonden. Heb je de juiste code ingegeven?";
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View();
        }
    }
}
