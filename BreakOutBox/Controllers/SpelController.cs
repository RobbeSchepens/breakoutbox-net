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

            Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(Decode(groepid))); // er moet een groep binnenkomen
            SpelSpelenViewModel ssvm = new SpelSpelenViewModel();
            
            ssvm.ProgressieInPad = groep.Pad.getProgressie();
            ssvm.Opdracht = groep.Pad.getCurrentOpdracht();
            ssvm.ToegangscodeVolgendeOefening = groep.Pad.getNextOpdracht().Toegangscode.Code.ToString();
            ssvm.GroepId = groep.GroepId;
            return View(ssvm);

        }

        [HttpPost]
        public IActionResult SpelSpelen(/*Groep groep,*/ SpelSpelenViewModel ssvm) // met die filter groep doorgeven (en ook sessie mss)
        {
            // vervangen door filter, sessie moet niet megegeven worden enkel groep
            Sessie sessie = _sessieRepository.GetBySessieCode("ABC");
            Groep groep = sessie.Groepen.FirstOrDefault(g => g.GroepId == ssvm.GroepId);
            // vervangen door filter

            if (ModelState.IsValid)
            {
                try
                {                   
                    if (groep.Pad.getCurrentOpdracht().isOpgelost(ssvm.Groepsantwoord))
                    {
                        ssvm.JuistGeantwoordOpgave = true;
                        ssvm.JuistGeantwoordtoegangscode = false;
                    }
                    if (ssvm.JuistGeantwoordOpgave) // er is een juist antwoord gegeven
                    {
                        if(ssvm.JuistGeantwoordtoegangscodeString == "True")
                        {
                            ssvm.JuistGeantwoordtoegangscode = ssvm.convertTextToBool(ssvm.JuistGeantwoordtoegangscodeString);
                        }

                        if (ssvm.JuistGeantwoordtoegangscode) // toegangscode en oplossing juist
                        {
                            groep.Pad.getCurrentOpdracht().Opgelost = true;
                            _sessieRepository.SaveChanges();
                            ssvm.Opdracht = groep.Pad.getCurrentOpdracht();/////
                            ssvm.ProgressieInPad = groep.Pad.getProgressie();
                            ssvm.JuistGeantwoordOpgave = false;
                            ssvm.JuistGeantwoordtoegangscode = false;
                            ssvm.ToegangscodeVolgendeOefening = groep.Pad.getNextOpdracht().Toegangscode.Code.ToString();
                            return View(ssvm);
                        }
                        else // enkel antwoord juist
                        {
                            ssvm.Opdracht = groep.Pad.getCurrentOpdracht();
                            _sessieRepository.SaveChanges();
                            ssvm.JuistGeantwoordOpgave = true;
                            
                            ssvm.ProgressieInPad = groep.Pad.getProgressie();
                            ssvm.ToegangscodeVolgendeOefening = groep.Pad.getNextOpdracht().Toegangscode.Code.ToString();
                            return View(ssvm);
                        }
                                    
                    }
                    else // er is geen juist antwoord gegeven
                    {
                        if (groep.Pad.getCurrentOpdracht().foutePogingen <= 2)
                        {
                            groep.Pad.getCurrentOpdracht().Opgelost = false;   // de vraag blijft op onOpgelost staan       
                            groep.Pad.getCurrentOpdracht().foutePogingen++; // foutpogingen +1 wanneer fout antwoord
                            _sessieRepository.SaveChanges();
                            ssvm.ProgressieInPad = groep.Pad.getProgressie();
                            ssvm.Opdracht = groep.Pad.getCurrentOpdracht();
                            ssvm.JuistGeantwoordOpgave = false;
                            ssvm.JuistGeantwoordtoegangscode = false;
                            ssvm.ToegangscodeVolgendeOefening = groep.Pad.getNextOpdracht().Toegangscode.Code.ToString();

                            TempData["FouteCode"] = "FOUT! je hebt " + groep.Pad.getCurrentOpdracht().foutePogingen + " foute pogingen ondernomen";
                            return View(ssvm);
                        }
                        else
                        {

                        }                      
                    }

                    #region Comments
                    /*
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
                          groep.SwitchState(groep.State);
                          groep.Blokkeer();
                          _sessieRepository.SaveChanges();
                          //Sessie sessie = _sessieRepository.GetBySessieCode(id);
                          //sessie.SwitchState(sessie.State);
                          //sessie.Blokkeer();
                          //_sessieRepository.SaveChanges();
                          //return RedirectToAction(nameof(OverzichtGroepenInSessie), new { id });
                      }
                  }*/
                    #endregion

                }
                catch
                {
                    ViewData["errorGeenVOlgendeOpdracht"] = "Er is geen volgende opdracht gevonden";
                }
            }
            return View();
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