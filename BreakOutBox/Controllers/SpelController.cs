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

            int nummerGroep = 1;
            string sessieCode = "ABC"; // deze 2 moeten op een speciale manier worden geimporteerd


            Sessie s = _sessieRepository.GetBySessieCode(sessieCode);
            Groep groep = s.Groepen.ToList()[nummerGroep - 1];

            return View(new SpelSpelenViewModel(s, groep));
        }
        [HttpPost]
        public IActionResult SpelSpelen(SpelSpelenViewModel ssvm)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    try
                    {
                     
                        
                    }
                    catch
                    {
                        TempData["errorGeenVOlgendeOpdracht"] = "Er is geen volgende opdracht gevonden";
                    }
                    
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View(ssvm);
        }

    }
}