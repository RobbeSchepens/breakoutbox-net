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

        public IActionResult Index()
        {
            Leerkracht lk = _leerkrachtRepository.GetByEmail(User.Identity.GetUserName()); // de leerkracht die vebonden staat met de huidige user
            List<Sessie> sessiesVanLeerkracht = lk.Sessies.ToList();

            foreach (Sessie sessie in sessiesVanLeerkracht)
            {
                sessie.SwitchState(sessie.State);
                foreach (Groep groep in sessie.Groepen)
                {
                    groep.SwitchState(groep.State);
                }
            }

            ViewData["LeerkrachtNaam"] = lk.Voornaam + " " + lk.Achternaam;
            return View(sessiesVanLeerkracht);
        }

        public IActionResult OverzichtGroepenInSessie(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
            sessie.SwitchState(sessie.State);
            foreach (Groep groep in sessie.Groepen)
            {
                groep.SwitchState(groep.State);
            }
            return View(sessie);
        }

        public IActionResult ActiveerSessie(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
            sessie.SwitchState(sessie.State);
            sessie.Activeer();
            _sessieRepository.SaveChanges();
            return RedirectToAction(nameof(OverzichtGroepenInSessie), new { id });
        }

        public IActionResult DeactiveerSessie(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
            sessie.SwitchState(sessie.State);
            sessie.Deactiveer();
            _sessieRepository.SaveChanges();
            return RedirectToAction(nameof(OverzichtGroepenInSessie), new { id });
        }

        public IActionResult BlokkeerSessie(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
            sessie.SwitchState(sessie.State);
            sessie.Blokkeer();
            _sessieRepository.SaveChanges();
            return RedirectToAction(nameof(OverzichtGroepenInSessie), new { id });
        }

        public IActionResult DeblokkeerSessie(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
            sessie.SwitchState(sessie.State);
            sessie.Deblokkeer();
            _sessieRepository.SaveChanges();
            return RedirectToAction(nameof(OverzichtGroepenInSessie), new { id });
        }

        public IActionResult StartSpelSessie(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
            sessie.SwitchState(sessie.State);
            sessie.StartSpel();
            _sessieRepository.SaveChanges();
            return RedirectToAction(nameof(OverzichtGroepenInSessie), new { id });
        }

        public IActionResult OverzichtGroep(int id1, string code)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Sessie sessie = _sessieRepository.GetBySessieCode(code);
                    sessie.SwitchState(sessie.State);
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == id1);
                    groep.SwitchState(groep.State);
                    return View(groep);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View();
        }

        public IActionResult ZetGroepGereed(string id, int groepid)
        {
            //sessiecode = Encode(sessiecode);

            if (ModelState.IsValid)
            {
                try
                {
                    Sessie sessie = _sessieRepository.GetBySessieCode(Decode(id));
                    sessie.SwitchState(sessie.State);
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == groepid);
                    groep.SwitchState(groep.State);
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
            return RedirectToAction(nameof(OverzichtGroepenInSessie), "Leerkracht", new { id });
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
