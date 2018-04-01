using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using BreakOutBox.Models.SessieViewModels;
using Microsoft.AspNetCore.Authorization;
using BreakOutBox.Filters;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BreakOutBox.Controllers
{
    [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
    public class SessieController : Controller
    {
        private readonly ISessieRepository _sessieRepository;

        public SessieController(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        public IActionResult SessieOverzicht(Sessie sessie, Groep groep)
        {
            // Check of de cookie "groepid" leeg is.
            if (HttpContext.Session.GetString("groepid") != null)
            {
                // Geef een extra object mee aan de view via ViewBag
                ViewBag.GeselecteerdeGroep = groep;
            }
            return View(sessie);
        }

        public IActionResult ZetGroepGereed(Sessie sessie, Groep groep, string groepid)
        {
            // Check of de cookie "groepid" leeg is.
            if (HttpContext.Session.GetString("groepid") == null)
            {
                try
                {
                    // Cookie toewijzen
                    HttpContext.Session.SetString("groepid", JsonConvert.SerializeObject(groepid));

                    // State veranderen
                    groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                    groep.SwitchState(groep.State);
                    groep.ZetGereed();
                    _sessieRepository.SaveChanges();

                    // Boodschap
                    TempData["message"] = $"Je hebt groep {groep.GroepId} gekozen.";
                }
                catch (Exception e)
                {
                    TempData["message"] = e;
                }
            }
            else
            {
                TempData["message"] = $"Je hebt al een groep gekozen.";
            }
            return RedirectToAction(nameof(SessieOverzicht));
        }

        public IActionResult ZetGroepNietGereed(Sessie sessie, Groep groep)
        {
            // Check of de cookie "groepid" leeg is.
            if (HttpContext.Session.GetString("groepid") != null)
            {
                try
                {
                    // State veranderen
                    groep.ZetNietGereed();
                    _sessieRepository.SaveChanges();

                    // Cookie leegmaken
                    HttpContext.Session.Remove("groepid");

                    // Boodschap
                    TempData["message"] = $"Groep {groep.GroepId} is nu terug beschikbaar.";
                }
                catch (Exception e)
                {
                    TempData["message"] = e;
                }
            }
            else
            {
                TempData["message"] = $"Je hebt geen groep gereed gezet.";
            }
            return RedirectToAction(nameof(SessieOverzicht));
        }

        public IActionResult StartSpel(Sessie sessie, Groep groep)
        {
            // Check of de cookie "groepid" leeg is.
            if (HttpContext.Session.GetString("groepid") != null)
            {
                // Naar SpelController
                return RedirectToAction(nameof(SpelController.SpelSpelen), "Spel");
            }
            else
            {
                TempData["message"] = $"Je hebt geen groep gekozen. Je kunt het spel niet spelen zonder groep.";
            }
            return RedirectToAction(nameof(SessieOverzicht));
        }
    }
}
