using System.Collections.Generic;
using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using BreakOutBox.Models.SpelViewModels;
using BreakOutBox.Filters;
using System;

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
        public IActionResult SpelSpelen(Groep groep)
        {
            SpelSpelenViewModel ssvm = new SpelSpelenViewModel();
            ssvm = geefSsvmAangepastTerug(ssvm,
                groep.Pad.GetCurrentOpdracht(),
                false,
                false,
                groep.Pad.GetNextOpdracht().Toegangscode.Code.ToString(),
                groep.Pad.GetProgressie());
            TempData["State"] = groep.State;

            // Foute pogingen
            int pogingen = groep.Pad.GetCurrentOpdracht().FoutePogingen;
            if (pogingen != 0)
                TempData["danger"] = "Fout! Je hebt " + pogingen + " foute " + (pogingen == 1 ? "poging" : "pogingen") + " ondernomen.";

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
        public IActionResult SpelSpelen(SpelSpelenViewModel ssvm, Sessie sessie, Groep groep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData["State"] = groep.State;

                    if (groep.Pad.GetCurrentOpdracht().IsOpgelost(ssvm.Groepsantwoord))
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
                            groep.Pad.GetCurrentOpdracht().Opgelost = true;
                            _sessieRepository.SaveChanges();
                            ssvm = geefSsvmAangepastTerug(ssvm, groep.Pad.GetCurrentOpdracht(), false, false, groep.Pad.GetNextOpdracht().Toegangscode.Code.ToString(), groep.Pad.GetProgressie());
                            //ssvm.Groepsantwoord = ""; // werkt niet
                            return View(ssvm);
                        }
                        else // enkel antwoord juist
                        {
                            _sessieRepository.SaveChanges();
                            ssvm = geefSsvmAangepastTerug(ssvm, groep.Pad.GetCurrentOpdracht(), true, ssvm.JuistGeantwoordtoegangscode, groep.Pad.GetNextOpdracht().Toegangscode.Code.ToString(), groep.Pad.GetProgressie());
                            //if (groep.CurrentState is GroepVergrendeldState || groep.CurrentState is GroepGeblokkeerdState)
                            //{
                            //    return RedirectToAction(nameof(Feedback));
                            //}
                            //else
                            //{
                            //    return View(ssvm);
                            //}
                            return View(ssvm);
                        }
                    }
                    else // er is geen juist antwoord gegeven
                    {
                        if (groep.Pad.GetCurrentOpdracht().FoutePogingen <= 1)
                        {
                            groep.Pad.GetCurrentOpdracht().Opgelost = false;   // de vraag blijft op onOpgelost staan
                            groep.Pad.GetCurrentOpdracht().FoutePogingen++; // foutpogingen +1 wanneer fout antwoord
                            ssvm = geefSsvmAangepastTerug(ssvm, groep.Pad.GetCurrentOpdracht(), false, false, groep.Pad.GetNextOpdracht().Toegangscode.Code.ToString(), groep.Pad.GetProgressie());
                            _sessieRepository.SaveChanges();
                            int pogingen = groep.Pad.GetCurrentOpdracht().FoutePogingen;
                            TempData["danger"] = "Fout! Je hebt " + pogingen + " foute " + (pogingen == 1 ? "poging" : "pogingen") + " ondernomen.";
                            TempData["State"] = groep.State;
                            //if (groep.CurrentState is GroepVergrendeldState || groep.CurrentState is GroepGeblokkeerdState)
                            //{
                            //    groep.Pad.getCurrentOpdracht().FoutePogingen++; // foutpogingen +1 wanneer fout antwoord
                            //    return RedirectToAction(nameof(Feedback));
                            //}
                            //else
                            //{
                            //    return View(ssvm);
                            //}
                            return View(ssvm);
                        }
                        else //if(groep.Pad.getCurrentOpdracht().FoutePogingen >= 3)
                        {
                            // State veranderen
                            groep.Blokkeer();
                            _sessieRepository.SaveChanges();

                            TempData["State"] = groep.State;
                            return RedirectToAction(nameof(Feedback));
                        }
                    }
                }
                catch
                {
                }
            }
            return View();
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult Feedback(SpelSpelenViewModel ssvm, Sessie sessie, Groep groep)
        {
            TempData["State"] = groep.State;

            ssvm = geefSsvmAangepastTerug(ssvm, groep.Pad.GetCurrentOpdracht(), false, false, groep.Pad.GetNextOpdracht().Toegangscode.Code.ToString(), groep.Pad.GetProgressie());
            ssvm.Opdracht.FoutePogingen = 0;
            _sessieRepository.SaveChanges();
            return View(sessie);
        }

        [HttpPost]
        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult Feedback(Sessie sessie, Groep groep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempData["State"] = groep.State;
                    return RedirectToAction(nameof(SpelSpelen));
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View(sessie);
        }
    }
}