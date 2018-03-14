using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using BreakOutBox.Models.SpelViewModels;

namespace BreakOutBox.Controllers
{
    public class SpelController : Controller
    {
        private readonly ISessieRepository _sessieRepository;

        public SpelController(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        [HttpGet]
        public IActionResult SpelSpelen()
        {

            int groepId = 0;
            string SessieCode = "ABC"; // deze 2 moeten op een speciale manier worden geimporteerd



            return View(new SpelSpelenViewModel(SessieCode, groepId));
        }
        [HttpPost]
        public IActionResult SpelSpelen(SpelSpelenViewModel ssvm)
        {

            return View();
        }

    }
}