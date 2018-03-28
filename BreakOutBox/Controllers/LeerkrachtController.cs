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
                    // Check of de cookie "sessiecode" leeg is.
                    if (HttpContext.Session.GetString("sessiecode") == null)
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
        
        public IActionResult OverzichtGroep(Sessie sessie, Groep groep, string groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Cookie toewijzen
                    HttpContext.Session.SetString("groepid", JsonConvert.SerializeObject(groepid));

                    return View(groep);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View();
        }

        public IActionResult BlokkeerGroep(Sessie sessie, Groep groep)
        {
            if (ModelState.IsValid)
            {
                try
                {
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

        public IActionResult DeblokkeerGroep(Sessie sessie, Groep groep)
        {
            if (ModelState.IsValid)
            {
                try
                {
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

        public IActionResult OntgrendelGroep(Sessie sessie, Groep groep)
        {
            if (ModelState.IsValid)
            {
                try
                {
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

        public IActionResult VergrendelGroep(Sessie sessie, Groep groep)
        {
            if (ModelState.IsValid)
            {
                try
                {
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

        public IActionResult ZetGroepGereed(Sessie sessie, Groep groep)
        {
            if (ModelState.IsValid)
            {
                try
                {
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

        public IActionResult ZetGroepNietGereed(Sessie sessie, Groep groep)
        {
            if (ModelState.IsValid)
            {
                try
                {
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
