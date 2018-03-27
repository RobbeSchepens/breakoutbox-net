using System.Collections.Generic;
using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using BreakOutBox.Models.SpelViewModels;
using BreakOutBox.Filters;

namespace BreakOutBox.Controllers
{
    public class SpelController : Controller
    {
        private readonly ISessieRepository _sessieRepository;

        public SpelController(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult SpelSpelen(Sessie sessie, Groep groep)
        {
            SpelSpelenViewModel ssvm = new SpelSpelenViewModel();
            ssvm = geefSsvmAangepastTerug(ssvm, 
                groep.Pad.getCurrentOpdracht(), 
                ssvm.JuistGeantwoordOpgave = ssvm.JuistGeantwoordOpgave, 
                ssvm.JuistGeantwoordtoegangscode = ssvm.JuistGeantwoordtoegangscode, 
                groep.Pad.getNextOpdracht().Toegangscode.Code.ToString(), 
                groep.Pad.getProgressie());
            return View(ssvm);
        }

        public SpelSpelenViewModel geefSsvmAangepastTerug(SpelSpelenViewModel ssvm, Opdracht opdracht, bool juistGeantwoordOpgave, bool juistGeantwoordtoegangscode, string toegangscodeVolgendeOefening, List<int> progressieInPad)
        {
            ssvm.Opdracht = opdracht;
            ssvm.JuistGeantwoordOpgave = juistGeantwoordOpgave;
            ssvm.JuistGeantwoordtoegangscode = juistGeantwoordtoegangscode;
            ssvm.ToegangscodeVolgendeOefening = toegangscodeVolgendeOefening;
            ssvm.ProgressieInPad = progressieInPad;
            return ssvm;
        }

        [HttpPost]
        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult SpelSpelen(/*Groep groep,*/ SpelSpelenViewModel ssvm, Sessie sessie, Groep groep) // met die filter groep doorgeven (en ook sessie mss)
        {
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
                        if (ssvm.JuistGeantwoordtoegangscodeString == "True")
                        {
                            ssvm.JuistGeantwoordtoegangscode = ssvm.convertTextToBool(ssvm.JuistGeantwoordtoegangscodeString);
                        }

                        if (ssvm.JuistGeantwoordtoegangscode) // toegangscode en oplossing juist
                        {
                            groep.Pad.getCurrentOpdracht().Opgelost = true;
                            _sessieRepository.SaveChanges();
                            ssvm = geefSsvmAangepastTerug(ssvm, groep.Pad.getCurrentOpdracht(), false, false, groep.Pad.getNextOpdracht().Toegangscode.Code.ToString(), groep.Pad.getProgressie());
                            return View(ssvm);
                        }
                        else // enkel antwoord juist
                        {
                            _sessieRepository.SaveChanges();
                            ssvm = geefSsvmAangepastTerug(ssvm, groep.Pad.getCurrentOpdracht(), true, ssvm.JuistGeantwoordtoegangscode, groep.Pad.getNextOpdracht().Toegangscode.Code.ToString(), groep.Pad.getProgressie());
                            return View(ssvm);
                        }
                    }
                    else // er is geen juist antwoord gegeven
                    {
                        if (groep.Pad.getCurrentOpdracht().foutePogingen <= 1)
                        {
                            groep.Pad.getCurrentOpdracht().Opgelost = false;   // de vraag blijft op onOpgelost staan
                            groep.Pad.getCurrentOpdracht().foutePogingen++; // foutpogingen +1 wanneer fout antwoord
                            ssvm = geefSsvmAangepastTerug(ssvm, groep.Pad.getCurrentOpdracht(), false, false, groep.Pad.getNextOpdracht().Toegangscode.Code.ToString(), groep.Pad.getProgressie());
                            _sessieRepository.SaveChanges();
                            TempData["FouteCode"] = "FOUT! je hebt " + groep.Pad.getCurrentOpdracht().foutePogingen + " foute pogingen ondernomen";
                            TempData["State"] = groep.State;
                            return View(ssvm);
                        }
                        else //if(groep.Pad.getCurrentOpdracht().foutePogingen >= 3)
                        {
                            groep.SwitchState(3);
                            //groep.Blokkeer();
                            //groep.Pad.getCurrentOpdracht().Opgelost = false;   // de vraag blijft op onOpgelost staan 
                            //groep.Pad.getCurrentOpdracht().foutePogingen ++;
                            //ssvm.ProgressieInPad = groep.Pad.getProgressie();
                            //ssvm.Opdracht = groep.Pad.getCurrentOpdracht();
                            //ssvm.JuistGeantwoordOpgave = false;
                            //ssvm.JuistGeantwoordtoegangscode = false;
                            //ssvm.ToegangscodeVolgendeOefening = groep.Pad.getNextOpdracht().Toegangscode.Code.ToString();
                            //ssvm = geefSsvmAangepastTerug(ssvm, groep.Pad.getCurrentOpdracht(), false, false, groep.Pad.getNextOpdracht().Toegangscode.Code.ToString(), groep.Pad.getProgressie());

                            TempData["State"] = groep.State;
                            _sessieRepository.SaveChanges();
                            return RedirectToAction(nameof(Feedback));
                        }
                    }
                }
                catch
                {
                    ViewData["errorGeenVOlgendeOpdracht"] = "Er is geen volgende opdracht gevonden";
                }
            }
            return View();
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult Opnieuw(Sessie sessie, Groep groep, SpelSpelenViewModel ssvm)
        {
            if (groep.State != 1)
            {
                TempData["message"] = $"Deze groep is niet gereed.";
                return RedirectToAction(nameof(SpelSpelenViewModel));
            }
            else
            {
                ssvm.Opdracht.foutePogingen = 0;
                groep.Pad.getCurrentOpdracht().Opgelost = false;
                ssvm.ProgressieInPad = groep.Pad.getProgressie();
                ssvm.Opdracht = groep.Pad.getCurrentOpdracht();
                ssvm.JuistGeantwoordOpgave = false;
                ssvm.JuistGeantwoordtoegangscode = false;
                ssvm.ToegangscodeVolgendeOefening = groep.Pad.getNextOpdracht().Toegangscode.Code.ToString();

                return View(new SpelSpelenViewModel(sessie, groep));
            }
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult Feedback(SpelSpelenViewModel ssvm, Sessie sessie, Groep groep)
        {
            TempData["State"] = groep.State;
            return View(ssvm);
        }
    }
}