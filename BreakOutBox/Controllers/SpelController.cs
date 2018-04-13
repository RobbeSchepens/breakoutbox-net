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
            int pogingen = groep.Pad.GetCurrentOpdracht().FoutePogingen;
            if (pogingen != 0)
                TempData["danger"] = $"Je hebt {pogingen} foute {(pogingen == 1 ? "poging" : "pogingen")} ondernomen.";

            return View(new SpelViewModel(groep));
        }

        [HttpPost]
        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult SpelSpelen(Groep groep, SpelViewModel svm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    groep.VerwerkAntwoord(svm.Groepsantwoord);
                }
                catch (DrieFoutePogingenException e)
                {
                    groep.Blokkeer();
                    _sessieRepository.SaveChanges();
                    TempData["danger"] = e.Message;
                    return RedirectToAction(nameof(Feedback));
                }
                catch (TijdVerstrekenException e)
                {
                    groep.Blokkeer();
                    _sessieRepository.SaveChanges();
                    TempData["danger"] = e.Message;
                    return RedirectToAction(nameof(Feedback));
                }
                catch (FoutAntwoordException)
                {
                    int pogingen = groep.Pad.GetCurrentOpdracht().FoutePogingen;
                    if (pogingen != 0)
                        TempData["danger"] = $"{svm.Groepsantwoord} is fout! Je hebt {pogingen} foute {(pogingen == 1 ? "poging" : "pogingen")} ondernomen.";
                    else
                        TempData["danger"] = $"{svm.Groepsantwoord} is fout!";
                }
                catch (AlleOpdrachtenVoltooidException)
                {
                }
                catch (Exception e)
                {
                    TempData["warning"] = e;
                }
            }

            _sessieRepository.SaveChanges();
            SpelViewModel svmMetInput = new SpelViewModel(groep)
            {
                Groepsantwoord = svm.Groepsantwoord
            };
            return View(svmMetInput);
        }

        [HttpPost]
        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult VerwerkToegangscode(Groep groep, SpelViewModel svm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    groep.VerwerkToegangscode(svm.Toegangscode);
                    _sessieRepository.SaveChanges();
                }
                catch (FouteToegangscodeException)
                {
                    TempData["foutetoegangscode"] = TempData["warning"] = $"De toegangscode {svm.Toegangscode} is fout.";
                }
                catch (Exception e)
                {
                    TempData["warning"] = e;
                }
            }

            SpelViewModel svmMetInput = new SpelViewModel(groep)
            {
                Toegangscode = svm.Toegangscode
            };
            return View(nameof(SpelSpelen), svmMetInput);
        }

        [HttpPost]
        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult VolgendeOpdracht(Groep groep)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    groep.StartVolgendeOpdracht();
                    _sessieRepository.SaveChanges();
                }
                catch (Exception e)
                {
                    TempData["warning"] = e;
                }
            }
            return View(nameof(SpelSpelen), new SpelViewModel(groep));
        }

        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult Feedback(Groep groep)
        {
            ViewData["State"] = groep.State;
            return View(new SpelViewModel(groep));
        }

        [HttpPost]
        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult Feedback(Groep groep, SpelViewModel svm)
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
            return View(new SpelViewModel(groep));
        }
    }
}