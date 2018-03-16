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
                            return RedirectToAction("SessieOverzicht", new { sessiecode = Encode(ivm.SessieCode) });
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
        public IActionResult SessieOverzicht(string sessiecode, string groepid)
        {
            


            Sessie sessie = _sessieRepository.GetBySessieCode(Decode(sessiecode));
            if (groepid != null)
            {

                groepid = (Decode(groepid)); // decoderen van groepId indien deze is gegeven
                Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                ViewBag.GeselecteerdeGroep = groep;
            }
            return View(sessie);
        }
        #region  commentsSpelOverzicht
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
        #endregion

        public IActionResult ZetGroepGereed(string sessiecode, string groepid)
        {          
            sessiecode = Encode(sessiecode);
        
            if (ModelState.IsValid)
            {
                try
                {
                    Sessie sessie = _sessieRepository.GetBySessieCode(Decode(sessiecode));
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(Decode(groepid)));
                    groep.SwitchState(groep.State);
                    groep.ZetGereed();
                    _sessieRepository.SaveChanges();
                    TempData["message"] = $"Je hebt groep {groep.GroepId} gekozen.";
                }
                catch (Exception e)
                {
                    //ModelState.AddModelError("", e.Message);
                    TempData["message"] = $"Deze groep werd al gekozen.";
                    return RedirectToAction(nameof(SessieOverzicht), new { sessiecode });
                }
            }

            
            return RedirectToAction(nameof(SessieOverzicht), new { sessiecode, groepid });
        }

        public IActionResult ZetGroepNietGereed(string sessiecode, string groepid)
        {
            sessiecode = Encode(sessiecode);
            

            if (ModelState.IsValid)
            {
                try
                {
                    Sessie sessie = _sessieRepository.GetBySessieCode(Decode(sessiecode));
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(Decode(groepid)));
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

        public IActionResult StartSpel(string sessiecode, string groepid)
        {

            sessiecode = Encode(sessiecode);
            groepid = Encode(groepid);

            return RedirectToAction(nameof(SpelController.SpelSpelen), "Spel", new { sessiecode, groepid });
        }

        public string Encode(string encodeMe)
        {
            byte[] encoded = System.Text.Encoding.UTF8.GetBytes(encodeMe);
            return Convert.ToBase64String(encoded);
        }

        public static string Decode(string decodeMe)
        {
            byte[] encoded = Convert.FromBase64String(decodeMe);
            return System.Text.Encoding.UTF8.GetString(encoded);
        }
    }
}
