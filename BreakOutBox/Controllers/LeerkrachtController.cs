using BreakOutBox.Filters;
using BreakOutBox.Models.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace BreakOutBox.Controllers
{
    //[AutoValidateAntiforgeryToken]
    //[Authorize(Policy = "leerkrachtAuth")]
    public class LeerkrachtController : Controller
    {
        private readonly ISessieRepository _sessieRepository;
        private readonly ILeerkrachtRepository _leerkrachtRepository;

        public LeerkrachtController(ISessieRepository sessieRepository, ILeerkrachtRepository leerkrachtRepository)
        {
            _sessieRepository = sessieRepository;
            _leerkrachtRepository = leerkrachtRepository;
        }

        [ServiceFilter(typeof(LeerkrachtFilter))]
        public IActionResult Index(Leerkracht leerkracht)
        {
            ViewData["LeerkrachtNaam"] = leerkracht.Voornaam + " " + leerkracht.Achternaam;
            return View(leerkracht);
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult OverzichtGroepenInSessie(Sessie sessie)
        {
            return View(sessie);
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult ActiveerSessie(Sessie sessie)
        {
            // State veranderen
            sessie.Activeer();
            _sessieRepository.SaveChanges();

            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult DeactiveerSessie(Sessie sessie)
        {
            // State veranderen
            sessie.Deactiveer();
            _sessieRepository.SaveChanges();

            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult BlokkeerSessie(Sessie sessie)
        {
            // State veranderen
            sessie.Blokkeer();
            _sessieRepository.SaveChanges();

            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult DeblokkeerSessie(Sessie sessie)
        {
            // State veranderen
            sessie.Deblokkeer();
            _sessieRepository.SaveChanges();

            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult StartSpelSessie(Sessie sessie)
        {
            // State veranderen
            sessie.StartSpel();
            _sessieRepository.SaveChanges();

            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult OverzichtGroep(Sessie sessie, Groep groep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return View(groep);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View();
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult ZetGroepGereed(Sessie sessie, Groep groep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    groep.ZetGereed();
                    _sessieRepository.SaveChanges();
                    TempData["message"] = $"Je hebt groep {groep.GroepId} gekozen.";
                }
                catch (Exception e)
                {
                    //ModelState.AddModelError("", e.Message);
                    TempData["message"] = $"Deze groep werd al gekozen.";
                }
            }
            //return View(nameof(LeerkrachtController.Index), "Leerkracht");
            return RedirectToAction(nameof(OverzichtGroepenInSessie), "Leerkracht");
        }
    }
}
