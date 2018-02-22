using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BreakOutBox.Models;
using BreakOutBox.Models.Domain;

namespace BreakOutBox.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISessieRepository _sessieRepository;

        public HomeController(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Your application description page.";

            /* 
             * DIT WAS VOOR TE TESTEN
             * Sessie s = _sessieRepository.GetByCode("321");
             ViewData["Sessies"] = s.Omschrijving;*/

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
