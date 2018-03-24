using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BreakOutBox.Models;
using BreakOutBox.Models.Domain;
using BreakOutBox.Models.SessieViewModels;
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
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult EnterSessie(string SessieCode)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Sessie sessie = _sessieRepository.GetBySessieCode(SessieCode);
                    if (sessie == null)
                        TempData["message"] = $"Deze sessie werd niet gevonden. Heb je de juiste code ingegeven?";
                    else
                    {
                        HttpContext.Session.SetString("sessiecode", sessie.Code);

                        if (sessie.State != 0)
                            return RedirectToAction(nameof(SessieController.SessieOverzicht), "Sessie", new { sessiecode = SessieCode });
                        else
                            TempData["message"] = $"Deze sessie is nog niet geactiveerd.";
                    }
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
