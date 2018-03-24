using BreakOutBox.Models.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace BreakOutBox.Controllers
{
    public class LeerkrachtController : Controller
    {
        // GET: /<controller>/
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
            ViewData["LeerkrachtNaam"] = lk.Voornaam + " " + lk.Achternaam;
            return View(sessiesVanLeerkracht);
        }

        public IActionResult OverzichtGroepenInSessie(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
            return View(sessie);
        }

        public IActionResult ActiveerSessie(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
            sessie.Activeer();
            _sessieRepository.SaveChanges();
            return RedirectToAction(nameof(OverzichtGroepenInSessie), new { id });
        }

        public IActionResult DeactiveerSessie(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
            sessie.Deactiveer();
            _sessieRepository.SaveChanges();
            return RedirectToAction(nameof(OverzichtGroepenInSessie), new { id });
        }

        public IActionResult BlokkeerSessie(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
            sessie.Blokkeer();
            _sessieRepository.SaveChanges();
            return RedirectToAction(nameof(OverzichtGroepenInSessie), new { id });
        }

        public IActionResult DeblokkeerSessie(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
            sessie.Deblokkeer();
            _sessieRepository.SaveChanges();
            return RedirectToAction(nameof(OverzichtGroepenInSessie), new { id });
        }

        public IActionResult StartSpelSessie(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);
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
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == id1);
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
