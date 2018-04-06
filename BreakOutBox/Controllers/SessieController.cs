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

                if (sessie.CurrentState is SessieGeblokkeerdState)
                    TempData["info"] = $"De sessie is momenteel geblokkeerd. Je kan nog niet aan de opdracht beginnen.";
                if (sessie.CurrentState is SessieActiefState)
                    TempData["info"] = $"Het spel is nog niet gestart. Nog even geduld.";
            }
            return View(sessie);
        }

        public IActionResult ZetGroepGekozen(Sessie sessie, Groep groep, string groepid)
        {
            if (groep != null)
            {
                try
                {
                    // State veranderen
                    groep.ZetGekozen();
                    _sessieRepository.SaveChanges();

                    // Boodschap
                    TempData["success"] = $"Je hebt groep #{groep.GroepId} gekozen.";

                    if (sessie.CurrentState is SessieGeblokkeerdState)
                        TempData["info"] = $"De sessie is momenteel geblokkeerd. Je kan nog niet aan de opdracht beginnen.";
                    if (sessie.CurrentState is SessieActiefState)
                        TempData["info"] = $"Het spel is nog niet gestart. Nog even geduld.";
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
        public IActionResult ZetGroepNietGekozen(Sessie sessie, Groep groep)
        {
            if (groep != null)
            {
                try
                {
                    // State veranderen
                    groep.ZetNietGekozen();
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

        [HttpPost]
        public IActionResult StartSpel(Sessie sessie, Groep groep)
        {
            if (groep != null)
            {
                try
                {
                    if (groep.CurrentState is GroepNietGekozenState || groep.CurrentState is GroepGekozenState || groep.CurrentState is GroepVergrendeldState)
                    {
                        // State veranderen
                        groep.ZetInSpel();
                        _sessieRepository.SaveChanges();
                    }

                    if (sessie.CurrentState is SessieGeblokkeerdState == false)
                        return RedirectToAction(nameof(SpelController.SpelSpelen), "Spel");
                    else
                        TempData["info"] = $"Deze sessie is momenteel geblokkeerd.";
                }
                catch (Exception e)
                {
                    TempData["warning"] = e;
                }
            }
            else
            {
                TempData["warning"] = $"Je hebt geen groep gekozen. Je kunt het spel niet spelen zonder groep.";
            }
            return RedirectToAction(nameof(SessieOverzicht));
        }
    }
}
