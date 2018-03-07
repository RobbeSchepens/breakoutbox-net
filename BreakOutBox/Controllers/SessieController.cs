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
            
            Sessie s = _sessieRepository.GetBySessieCode(id);
            var se = s;

            if (s == null)
                return RedirectToAction("Index", new { id = "onbestaand" });


           
            return View(s);
        }

        public IActionResult SpelOverzicht(string id)
        {

            Sessie sessie = _sessieRepository.GetBySessieCode(id);

            //MapSessieSpelOverichtViewModel(sesieViewModel,sessie);

            return View();
        }

        //private void MapSessieSpelOverichtViewModel(EditViewModel sesieViewModel, Sessie sessie)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
