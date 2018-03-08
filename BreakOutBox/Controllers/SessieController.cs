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
            //Sessie s = _sessieRepository.GetBySessieCode(id);

            //if (s == null)
            //    return RedirectToAction("Index", new { id = "onbestaand" });

            //return View(s);

            if (ModelState.IsValid)
            {
                try
                {
                    Sessie sessie = _sessieRepository.GetBySessieCode(ivm.SessieCode);
                    if (sessie == null)
                        TempData["message"] = $"mis.";
                    return RedirectToAction("SessieOverzicht", new { id=ivm.SessieCode});
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

    }
}
