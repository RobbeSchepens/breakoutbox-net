﻿using System.Collections.Generic;
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
            SpelViewModel svm = new SpelViewModel(groep);

            int pogingen = groep.Pad.GetCurrentOpdracht().FoutePogingen;
            if (pogingen != 0)
                TempData["danger"] = $"Je hebt {pogingen} foute {(pogingen == 1 ? "poging" : "pogingen")} ondernomen.";

            return View(svm);
        }

        [HttpPost]
        [ServiceFilter(typeof(SessieEnGroepSessionFilter))]
        public IActionResult SpelSpelen(Groep groep, SpelViewModel svm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    double.TryParse(svm.Groepsantwoord.Replace(',', '.'), out double doubleAntwoord);
                    groep.VerwerkAntwoord(doubleAntwoord);
                    _sessieRepository.SaveChanges();
                }
                catch (DrieFoutePogingenException)
                {
                    groep.Blokkeer();
                    _sessieRepository.SaveChanges();
                    
                    return RedirectToAction(nameof(Feedback));
                }
                catch (FoutAntwoordException)
                {
                    int pogingen = groep.Pad.GetCurrentOpdracht().FoutePogingen;
                    if (pogingen != 0)
                        TempData["danger"] = $"{svm.Groepsantwoord} is fout! Je hebt {pogingen} foute {(pogingen == 1 ? "poging" : "pogingen")} ondernomen.";
                }
                catch (Exception e)
                {
                    TempData["warning"] = e;
                }
            }

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
                    double.TryParse(svm.Toegangscode.Replace(',', '.'), out double doubleAntwoord);
                    groep.VerwerkToegangscode(doubleAntwoord);
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
        public IActionResult Feedback(SpelViewModel ssvm, Sessie sessie, Groep groep)
        {
            ViewData["State"] = groep.State;
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