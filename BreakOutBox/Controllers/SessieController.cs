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
                        if(sessie.State != 0)
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
        public IActionResult SpelOVerzicht(IndexViewModel ivm, string id)
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
                    return RedirectToAction("SpelOverzicht", new { id = id});
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View();
        }

        [ActionName("SessieOverzicht")]
        public IActionResult VergrendelGroep(string id, int groepid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Sessie sessie = _sessieRepository.GetBySessieCode(id);
                    Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == groepid);
                    groep.Vergrendel();
                    _sessieRepository.SaveChanges();
                    TempData["message"] = $"Groep {groep.GroepId} is nu vergrendeld.";
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
                //return RedirectToAction(nameof(Index));
            }
            //ViewData["IsEdit"] = true;
            //ViewData["Locations"] = GetLocationsAsSelectList();
            return View();
        }
    }
}
