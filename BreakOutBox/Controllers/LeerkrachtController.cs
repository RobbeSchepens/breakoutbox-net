using BreakOutBox.Filters;
using BreakOutBox.Models.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace BreakOutBox.Controllers
{
    [AutoValidateAntiforgeryToken]
    [Authorize(Policy = "leerkrachtAuth")]
    [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
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
            return View(leerkracht.Sessies.ToList());
        }
        
        public IActionResult OverzichtGroepenInSessie(Sessie sessie, string sessiecode)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (sessiecode != null)
                    {
                        // Cookie toewijzen
                        HttpContext.Session.SetString("sessiecode", JsonConvert.SerializeObject(sessiecode));

                        sessie = _sessieRepository.GetBySessieCode(sessiecode);
                        sessie.SwitchState(sessie.State);
                        foreach (Groep groep in sessie.Groepen)
                        {
                            groep.SwitchState(groep.State);
                        }
                    }

                    return View(sessie);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View();
        }
        
        public IActionResult ActiveerSessie(Sessie sessie)
        {
            // State veranderen
            sessie.Activeer();
            _sessieRepository.SaveChanges();

            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }
        
        public IActionResult DeactiveerSessie(Sessie sessie)
        {
            // State veranderen
            sessie.Deactiveer();
            _sessieRepository.SaveChanges();

            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }
        
        public IActionResult BlokkeerSessie(Sessie sessie)
        {
            // State veranderen
            sessie.Blokkeer();
            _sessieRepository.SaveChanges();

            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }
        
        public IActionResult DeblokkeerSessie(Sessie sessie)
        {
            // State veranderen
            sessie.Deblokkeer();
            _sessieRepository.SaveChanges();

            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }
        
        public IActionResult StartSpelSessie(Sessie sessie)
        {
            // State veranderen
            sessie.StartSpel();
            _sessieRepository.SaveChanges();

            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }

        public IActionResult BlokkeerGroep(Sessie sessie, string groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                    groep.Blokkeer();
                    _sessieRepository.SaveChanges();
                }
                catch (Exception e)
                {
                    //ModelState.AddModelError("", e.Message);
                    TempData["message"] = $"Deze groep kon niet geblokkeerd worden.";
                }
            }
            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }

        public IActionResult DeblokkeerGroep(Sessie sessie, string groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                    groep.DeBlokkeer();
                    _sessieRepository.SaveChanges();
                }
                catch (Exception e)
                {
                    //ModelState.AddModelError("", e.Message);
                    TempData["message"] = $"Deze groep kon niet gedeblokkeerd worden.";
                }
            }
            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }

        public IActionResult OntgrendelGroep(Sessie sessie, string groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                    groep.Ontgrendel();
                    _sessieRepository.SaveChanges();
                }
                catch (Exception e)
                {
                    //ModelState.AddModelError("", e.Message);
                    TempData["message"] = $"Deze groep kon niet ontgrendeld worden.";
                }
            }
            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }

        public IActionResult VergrendelGroep(Sessie sessie, string groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                    groep.Vergrendel();
                    _sessieRepository.SaveChanges();
                }
                catch (Exception e)
                {
                    //ModelState.AddModelError("", e.Message);
                    TempData["message"] = $"Deze groep kon niet vergrendeld worden.";
                }
            }
            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }

        public IActionResult ZetGroepGereed(Sessie sessie, string groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                    groep.ZetGereed();
                    _sessieRepository.SaveChanges();
                }
                catch (Exception e)
                {
                    //ModelState.AddModelError("", e.Message);
                    TempData["message"] = $"Deze groep kon niet klaar gezet worden worden.";
                }
            }
            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }

        public IActionResult ZetGroepNietGereed(Sessie sessie, string groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                    groep.ZetNietGereed();
                    _sessieRepository.SaveChanges();
                }
                catch (Exception e)
                {
                    //ModelState.AddModelError("", e.Message);
                    TempData["message"] = $"Deze groep kon niet onklaar gezet worden.";
                }
            }
            return RedirectToAction(nameof(OverzichtGroepenInSessie));
        }
    }
}
