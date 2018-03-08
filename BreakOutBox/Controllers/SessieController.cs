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

        public IActionResult Index(string id, IndexViewModel indexViewModel)
        {
            if (id == "onbestaand")
                ViewData["BestaatNietError"] = "Deze code werd niet gevonden. Heb je de juiste code ingevuld?";
            return View(indexViewModel);
        }

        //[HttpPost]
        public IActionResult SessieOverzicht(string id)
        {
            Sessie s = _sessieRepository.GetBySessieCode(id);

            if (s == null)
                return RedirectToAction("Index", new { id = "onbestaand" });

            return View(s);

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        Sessie sessie = _sessieRepository.GetBySessieCode(code);

            //        if (sessie == null)
            //            return RedirectToAction("Index", new { code = "onbestaand" });

            //        TempData["message"] = $"Je hebt nu toegang tot de sessie.";
            //        return View(sessie);
            //    }
            //    catch (Exception e)
            //    {
            //        ModelState.AddModelError("", e.Message);
            //    }
            //}
        }

        public IActionResult SpelOverzicht(string id)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(id);

            

            return View();
        }

    }
}
