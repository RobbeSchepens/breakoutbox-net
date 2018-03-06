using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BreakOutBox.Controllers
{
    public class SpelController : Controller
    {
        private readonly ISessieRepository _sessieRepository;

        public SpelController(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }


        public IActionResult Spel(string id)
        {


            //Sessie s = _sessieRepository.GetBySessieCode(id);
            //var se = s;

            //if (s == null)
            //    return RedirectToAction("Sessie", new { id = "onbestaand" });
            

            return View();
        }
    }
}