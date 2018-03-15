using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using BreakOutBox.Models.SessieViewModels;

namespace BreakOutBox.Controllers
{
    public class SessieController : Controller
    {
        private readonly ISessieRepository _sessieRepository;

        public SessieController(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        #region MyRegion

        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            return View(new IndexViewModel());
        }

        [HttpPost]
        public IActionResult Index(IndexViewModel ivm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Sessie sessie = _sessieRepository.GetBySessieCode(ivm.SessieCode);
                    if (sessie == null)
                        TempData["message"] = $"Deze sessie werd niet gevonden. Heb je de juiste code ingegeven?";
                    else
                    {
                        if (sessie.State != 0)
                            return RedirectToAction("SessieOverzicht", new { id = ivm.SessieCode });
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

        [HttpGet]
        public IActionResult SessieOverzicht(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
            return View(sessie);
        }

        [HttpGet]
        public IActionResult SpelOverzicht(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
            TempData["message"] = $"Groep {id}";
            return View(sessie);
        }

        [HttpPost]
        public IActionResult SpelOverzicht(IndexViewModel ivm, string id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Sessie sessie = _sessieRepository.GetBySessieCode(id);
                    if (sessie == null)
                    {
                        TempData["message2"] = "Probeer opnieuw";
                        return View();
                    }
                    return RedirectToAction("SpelOverzicht", new { id });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View();
        }

        public IActionResult ZetGroepGereed(int groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Sessie sessie = _sessieRepository.GetBySessieCode("ABC");
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == groepid);
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
            return RedirectToAction(nameof(SessieOverzicht), new { id = "ABC" });
        }

        public IActionResult ZetGroepNietGereed(int groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Sessie sessie = _sessieRepository.GetBySessieCode("ABC");
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == groepid);
                    groep.SwitchState(groep.State);
                    groep.ZetNietGereed();
                    _sessieRepository.SaveChanges();
                    TempData["message"] = $"Groep {groep.GroepId} is nu terug beschikbaar.";
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return RedirectToAction(nameof(SessieOverzicht), new { id = "ABC" });
        }
    }
}
