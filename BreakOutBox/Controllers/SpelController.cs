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
        public IActionResult SpelSpelen(string sessiecode, string groepid)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(Decode(sessiecode));
            Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(Decode(groepid)));
            return View(new SpelSpelenViewModel(sessie, groep));

            //int nummerGroep = 1;
            //string sessieCode = "ABC"; // deze 2 moeten op een speciale manier worden geimporteerd
            //Sessie s = _sessieRepository.GetBySessieCode(sessieCode);
            //Groep groep = s.Groepen.ToList()[nummerGroep - 1];
            //return View(new SpelSpelenViewModel(s, groep));
            //return RedirectToAction("SpelSpelen", new { ssvm = new SpelSpelenViewModel(s, groep) });
            //return RedirectToAction("SpelSpelen", new { ssvm = new SpelSpelenViewModel(s, groep) });
            //new SpelSpelenViewModel(s, groep)
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

                    if (ssvm.Groepsantwoord.ToString() == huidigeOpdracht.Oefening.Antwoord.ToString()) // dit moet de uitkomst na de groepsbewerking zijn (dus samenstelling antwoord en bewerking).
                    {
                        ssvm.Opdracht = nieweOpdracht;
                        ssvm.TellerFoutePogingen = 0;
                        //naar een scherm gaan voorr de toegangscode in te vullen (met de actie)
                    }
                    else
                    {
                        //if (ssvm.TellerFoutePogingen > 2)
                        //{
                        //    var i = 0;
                        //    // spel geblokkeerd en leerkracht moet het deblokkeren
                        //}
                        //else
                        //{
                        ssvm.Opdracht = huidigeOpdracht;
                        TempData["FouteCode"] = "FOUT! je hebt " + ssvm.TellerFoutePogingen + " foute pogingen ondernomen";
                        //}

                        if (ssvm.TellerFoutePogingen >= 2)
                        {
                            Groep groep = s.Groepen.Where(a => a.GroepId == ssvm.GroepId).FirstOrDefault();
                            groep.SwitchState(3);
                            groep.Blokkeer();
                            _sessieRepository.SaveChanges();
                            //Sessie sessie = _sessieRepository.GetBySessieCode(id);
                            //sessie.SwitchState(sessie.State);
                            //sessie.Blokkeer();
                            //_sessieRepository.SaveChanges();
                            //return RedirectToAction(nameof(OverzichtGroepenInSessie), new { id });
                        }
                    }
                }
                catch
                {
                    ViewData["errorGeenVOlgendeOpdracht"] = "Er is geen volgende opdracht gevonden";
                }
            }
            return View(ssvm);
        }

        public IActionResult Opnieuw(string sessiecode, string groepid, SpelSpelenViewModel ssvm)
        {
            Sessie sessie = _sessieRepository.GetBySessieCode(Decode(sessiecode));
            Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(Decode(groepid)));
            ssvm.TellerFoutePogingen = 0;
            return View(new SpelSpelenViewModel(sessie, groep));
        }

       /* public IActionResult InvoerenToegangscode(opdrachtId)
        {



            return View(ssvm);
        }*/

        public static string Decode(string decodeMe)
        {
            byte[] encoded = Convert.FromBase64String(decodeMe);
            return System.Text.Encoding.UTF8.GetString(encoded);
        }
    }
}