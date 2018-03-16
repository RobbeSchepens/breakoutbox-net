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
                            return RedirectToAction("SessieOverzicht", new { sessiecode = ivm.SessieCode });
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

        //[HttpGet]
        //public IActionResult SessieOverzicht(string sessiecode)
        //{
        //    Sessie sessie = _sessieRepository.GetBySessieCode(sessiecode);
        //    return View(sessie);
        //}

        [HttpGet]
        public IActionResult SessieOverzicht(string sessiecode, int? groepid = null)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(sessiecode);
            if (groepid != null)
            {
                Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == groepid);
                ViewBag.GeselecteerdeGroep = groep;
            }
            return View(sessie);
        }

        //[HttpGet]
        //public IActionResult SpelOverzicht(string sessiecode)
        //{
        //    Sessie sessie = _sessieRepository.GetBySessieCode(sessiecode);
        //    TempData["message"] = $"Groep {sessiecode}";
        //    return View(sessie);
        //}

        //[HttpPost]
        //public IActionResult SpelOverzicht(IndexViewModel ivm, string sessiecode)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            Sessie sessie = _sessieRepository.GetBySessieCode(sessiecode);
        //            if (sessie == null)
        //            {
        //                TempData["message2"] = "Probeer opnieuw";
        //                return View();
        //            }
        //            return RedirectToAction("SpelOverzicht", new { sessiecode });
        //        }
        //        catch (Exception e)
        //        {
        //            ModelState.AddModelError("", e.Message);
        //        }
        //    }
        //    return View();
        //}

        public IActionResult ZetGroepGereed(string sessiecode, int groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Sessie sessie = _sessieRepository.GetBySessieCode(sessiecode);
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
            return RedirectToAction(nameof(SessieOverzicht), new { sessiecode, groepid });
        }

        public IActionResult ZetGroepNietGereed(string sessiecode, int groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Sessie sessie = _sessieRepository.GetBySessieCode(sessiecode);
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
            return RedirectToAction(nameof(SessieOverzicht), new { sessiecode });
        }

        public IActionResult StartSpel(string sessiecode, int groepid)
        {
            return RedirectToAction(nameof(SpelController.SpelSpelen), "Spel", new { sessiecode, groepid });
        }
    }
}
