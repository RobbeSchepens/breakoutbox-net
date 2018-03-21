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
            /*string[] tokens = User.Identity.GetUserName().Split('_');
            int index = tokens[1].LastIndexOf("@");
            if (index > 0)
                tokens[1] = tokens[1].Substring(0, index);*/           
            Leerkracht lk = _leerkrachtRepository.GetByEmail(User.Identity.GetUserName()); // de leerkracht die vebonden staat met de huidige user
            List<Sessie> sessiesVanLeerkracht = lk.Sessies.ToList();

            foreach(Sessie sessie in sessiesVanLeerkracht)
            {
                sessie.SwitchState(sessie.State);
                foreach(Groep groep in sessie.Groepen)
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
    }
}
