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
    public class SessieController : Controller
    {
        private readonly ISessieRepository _sessieRepository;

        public SessieController(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult SessieOverzicht(Sessie sessie, Groep groep)
        {
            // Check of de cookie "groepid" leeg is.
            if (HttpContext.Session.GetString("groepid") != null)
            {
                ViewBag.GeselecteerdeGroep = groep;
            }
            return View(sessie);
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult ZetGroepGereed(Sessie sessie, Groep groep, string groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Check of de cookie "groepid" leeg is.
                    if (HttpContext.Session.GetString("groepid") == null)
                    {
                        // Cookie toewijzen
                        HttpContext.Session.SetString("groepid", JsonConvert.SerializeObject(groepid));
                        groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                        groep.SwitchState(groep.State);

                        // State veranderen
                        groep.ZetGereed();
                        _sessieRepository.SaveChanges();

                        // Boodschap
                        TempData["message"] = $"Je hebt groep {groep.GroepId} gekozen.";
                    }
                    else
                    {
                        TempData["message"] = $"Je hebt al een groep gekozen.";
                    }
                }
                catch (Exception e)
                {
                    //ModelState.AddModelError("", e.Message);
                    TempData["message"] = $"Deze groep werd al gekozen.";
                }
            }
            return RedirectToAction(nameof(SessieOverzicht));
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult ZetGroepNietGereed(Sessie sessie, Groep groep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Check of de cookie "groepid" leeg is.
                    if (HttpContext.Session.GetString("groepid") != null)
                    {
                        // State veranderen
                        groep.ZetNietGereed();
                        _sessieRepository.SaveChanges();

                        // Cookie leegmaken
                        HttpContext.Session.Remove("groepid");

                        // Boodschap
                        TempData["message"] = $"Groep {groep.GroepId} is nu terug beschikbaar.";
                    }
                    else
                    {
                        TempData["message"] = $"Je hebt geen groep gereed gezet.";
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return RedirectToAction(nameof(SessieOverzicht));
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
