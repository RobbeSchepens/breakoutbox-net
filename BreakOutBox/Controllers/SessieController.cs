using System;
using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using BreakOutBox.Filters;

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
            if (groep != null)
            {
                // Geef een extra object mee aan de view via ViewBag
                ViewBag.GeselecteerdeGroep = groep;
            }
            return View(sessie);
        }
        
        public IActionResult ZetGroepGereed(Sessie sessie, Groep groep, string groepid)
        {
            if (groep != null)
            {
                try
                {
                    // State veranderen
                    groep.ZetGereed();
                    _sessieRepository.SaveChanges();

                    // Boodschap
                    TempData["success"] = $"Je hebt groep #{groep.GroepId} gekozen.";
                }
                catch (Exception e)
                {
                    TempData["warning"] = e;
                }
            }
            else
            {
                TempData["warning"] = $"Je hebt geen groep mee gegeven.";
            }
            return RedirectToAction(nameof(SessieOverzicht));
        }

        [ServiceFilter(typeof(ClearGroepSessionFilter))]
        public IActionResult ZetGroepNietGereed(Sessie sessie, Groep groep)
        {
            if (groep != null)
            {
                try
                {
                    // State veranderen
                    groep.ZetNietGereed();
                    _sessieRepository.SaveChanges();
                    
                    // Boodschap
                    TempData["success"] = $"Je hebt groep #{groep.GroepId} gedeselecteerd.";
                }
                catch (Exception e)
                {
                    TempData["warning"] = e;
                }
            }
            else
            {
                TempData["warning"] = $"Je hebt geen groep gereed gezet.";
            }
            return RedirectToAction(nameof(SessieOverzicht));
        }

        public IActionResult StartSpel(Sessie sessie, Groep groep)
        {
            if (groep != null)
            {
                // Naar SpelController
                return RedirectToAction(nameof(SpelController.SpelSpelen), "Spel");
            }
            else
            {
                TempData["warning"] = $"Je hebt geen groep gekozen. Je kunt het spel niet spelen zonder groep.";
            }
            return RedirectToAction(nameof(SessieOverzicht));
        }
    }
}
