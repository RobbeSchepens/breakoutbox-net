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
                ViewData["BestaatNietError"] = "Deze sessie bestaat niet";
            return View(indexViewModel);
        }

        public IActionResult SessieOverzicht(string id)
        {
            string a = id;
            Sessie s = _sessieRepository.GetBySessieCode(id);
            if (s == null)
                return RedirectToAction("Index", new { id = "onbestaand" });
 

            // Dit kan ik pas verder doen als het domein goed is

             ViewData["code"] = id;
            return View();
        }


    }
}
