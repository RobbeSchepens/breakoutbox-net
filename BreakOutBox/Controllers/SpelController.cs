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

            // return RedirectToAction("SpelSpelen", new {ssvm = new SpelSpelenViewModel(s, groep) });
            // return RedirectToAction("SpelSpelen",  new { ssvm = new SpelSpelenViewModel(s, groep) });
            // new SpelSpelenViewModel(s, groep)

        }
        [HttpPost]
        public IActionResult SpelSpelen(SpelSpelenViewModel ssvm)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    Sessie s = _sessieRepository.GetBySessieCode(ssvm.sessieId); // sessieId = sessieCode (kan nog veranderd worden)
                    Groep g = s.Groepen.Where(a => a.GroepId == ssvm.GroepId).FirstOrDefault();
                    Opdracht huidigeOpdracht = g.Pad.Opdrachten.Where(a => a.OpdrachtId == ssvm.OpdrachtId).FirstOrDefault();
                    Opdracht nieweOpdracht = g.Pad.getNextOpdracht(huidigeOpdracht);
                    ssvm.Groep = g;
                    ssvm.Sessie = s;

                    if (ssvm.Toegangscode == huidigeOpdracht.Toegangscode.Code)
                    {
                        ssvm.Opdracht = nieweOpdracht;
                        ssvm.TellerFouteToegangscode = 0;
                    }
                    else
                    {
                        if (ssvm.TellerFouteToegangscode > 2)
                        {
                            var i = 0;
                            // spel geblokkeerd en leerkracht moet het deblokkeren
                        }
                        else
                        {
                            ssvm.Opdracht = huidigeOpdracht;
                            TempData["FouteCode"] = "FOUT! je hebt " + ssvm.TellerFouteToegangscode + " foute pogingen ondernomen";
                        }
                       
                    }

                    if (ssvm.TellerFouteToegangscode > 3)
                    {

                    }


                }
                catch
                {
                    ViewData["errorGeenVOlgendeOpdracht"] = "Er is geen volgende opdracht gevonden";
                }



            }
            return View(ssvm);
        }

    }
}