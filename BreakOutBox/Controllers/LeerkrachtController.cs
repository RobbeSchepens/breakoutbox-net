using BreakOutBox.Filters;
using BreakOutBox.Models.Domain;
using BreakOutBox.Models.LeerkrachtViewModels;
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

        public IActionResult SessieBeheren(Sessie sessie, string sessiecode)
        {
            if (sessie != null)
                return View(sessie);

            TempData["warning"] = "De sessie werd niet gevonden.";
            return View(nameof(Index));
        }

        /* ===================== ============ =====================
         * ===================== SESSIEACTIES =====================
         * ===================== ============ ===================== */
        public IActionResult ActiveerSessie(Sessie sessie)
        {
            try
            {
                // State veranderen
                sessie.Activeer();
                _sessieRepository.SaveChanges();
                TempData["success"] = $"De sessie is geactiveerd.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }

            return RedirectToAction(nameof(SessieBeheren));
        }

        public IActionResult DeactiveerSessie(Sessie sessie)
        {
            try
            {
                // State veranderen
                sessie.Deactiveer();
                _sessieRepository.SaveChanges();
                TempData["success"] = $"De sessie is gedeactiveerd.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }

            return RedirectToAction(nameof(SessieBeheren));
        }

        public IActionResult StartSpelSessie(Sessie sessie)
        {
            try
            {
                // State veranderen
                sessie.StartSpel();
                _sessieRepository.SaveChanges();

                TempData["success"] = $"Het spel is gestart.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }
            return RedirectToAction(nameof(SessieBeheren));
        }

        public IActionResult HaalSessieUitSpel(Sessie sessie)
        {
            try
            {
                // State veranderen
                sessie.HaalUitSpel();
                _sessieRepository.SaveChanges();

                TempData["success"] = $"Het spel is niet langer gestart.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }
            return RedirectToAction(nameof(SessieBeheren));
        }

        public IActionResult BlokkeerSessie(Sessie sessie)
        {
            try
            {
                // State veranderen
                sessie.Blokkeer();
                _sessieRepository.SaveChanges();
                TempData["success"] = $"De sessie is geblokkeerd.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }

            return RedirectToAction(nameof(SessieBeheren));
        }

        public IActionResult DeblokkeerSessie(Sessie sessie)
        {
            try
            {
                // State veranderen
                sessie.Deblokkeer();
                _sessieRepository.SaveChanges();
                TempData["success"] = $"De sessie is gedeblokkeerd.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }

            return RedirectToAction(nameof(SessieBeheren));
        }

        /* ===================== ============ =====================
         * ===================== GROEP ACTIES =====================
         * ===================== ============ ===================== */
        public IActionResult ZetGroepGekozen(Sessie sessie, string groepid)
        {
            try
            {
                Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                groep.ZetGekozen();
                _sessieRepository.SaveChanges();
                TempData["success"] = $"Groep #{groep.GroepId} staat nu op gekozen.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }
            return RedirectToAction(nameof(SessieBeheren));
        }

        public IActionResult ZetGroepNietGekozen(Sessie sessie, string groepid)
        {
            try
            {
                Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                groep.ZetNietGekozen();
                _sessieRepository.SaveChanges();
                TempData["success"] = $"Groep #{groep.GroepId} staat nu op niet gekozen.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }
            return RedirectToAction(nameof(SessieBeheren));
        }

        public IActionResult VergrendelGroep(Sessie sessie, string groepid)
        {
            try
            {
                Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                groep.Vergrendel();
                _sessieRepository.SaveChanges();
                TempData["success"] = $"Groep #{groep.GroepId} is nu vergrendeld.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }
            return RedirectToAction(nameof(SessieBeheren));
        }

        public IActionResult OntgrendelGroep(Sessie sessie, string groepid)
        {
            try
            {
                Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                groep.Ontgrendel();
                _sessieRepository.SaveChanges();
                TempData["success"] = $"Groep #{groep.GroepId} is nu ontgrendeld.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }
            return RedirectToAction(nameof(SessieBeheren));
        }

        public IActionResult ZetGroepInSpel(Sessie sessie, string groepid)
        {
            try
            {
                Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                groep.ZetInSpel();
                _sessieRepository.SaveChanges();
                TempData["success"] = $"Groep #{groep.GroepId} zit nu in het spel.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }
            return RedirectToAction(nameof(SessieBeheren));
        }

        public IActionResult HaalGroepUitSpel(Sessie sessie, string groepid)
        {
            try
            {
                Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                groep.HaalUitSpel();
                _sessieRepository.SaveChanges();
                TempData["success"] = $"Groep #{groep.GroepId} zit niet meer in het spel.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }
            return RedirectToAction(nameof(SessieBeheren));
        }

        public IActionResult BlokkeerGroep(Sessie sessie, string groepid)
        {
            try
            {
                Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                groep.Blokkeer();
                _sessieRepository.SaveChanges();
                TempData["success"] = $"Groep #{groep.GroepId} is nu geblokkeerd.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }
            return RedirectToAction(nameof(SessieBeheren));
        }

        public IActionResult DeblokkeerGroep(Sessie sessie, string groepid)
        {
            try
            {
                Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                groep.Deblokkeer();
                _sessieRepository.SaveChanges();
                TempData["success"] = $"Groep #{groep.GroepId} is nu gedeblokkeerd.";
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }
            return RedirectToAction(nameof(SessieBeheren));
        }

        public IActionResult DetailsOpdracht(Sessie sessie, string groepid)
        {
            try
            {
                Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                return View(new OpdrachtViewModel(groep));
            }
            catch (StateException e)
            {
                TempData["warning"] = e;
            }
            catch (Exception e)
            {
                TempData["warning"] = e;
            }
            return RedirectToAction(nameof(SessieBeheren));
        }

        [HttpPost]
        public IActionResult GeefGroepNieuweTijd(Sessie sessie, OpdrachtViewModel ovm, string groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(groepid));
                    int opgegevenminuten = ovm.OpgegevenMinuten;
                    OpdrachtViewModel ovmNew = new OpdrachtViewModel(groep);
                    ovmNew.Opdracht.GeefNieuweTijd(opgegevenminuten);
                    _sessieRepository.SaveChanges();

                    TempData["success"] = $"Groep #{groepid} heeft nu {opgegevenminuten} tijd gekregen.";
                    return RedirectToAction(nameof(DetailsOpdracht), new { groepid });
                }
                catch (Exception e)
                {
                    TempData["warning"] = e;
                }
            }
            return RedirectToAction(nameof(SessieBeheren));
        }
    }
}
