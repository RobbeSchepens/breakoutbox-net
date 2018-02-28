using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BreakOutBox.Controllers
{
    public class SessieController : Controller
    {

        private readonly ISessieRepository _sessieRepository;
        public SessieController(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;

        }
        public IActionResult Index()
        {

            return View("GeefSessieCode");
        }

        public IActionResult GeefSessieCode()
        {
            IEnumerable<Sessie> sessies;
            sessies = _sessieRepository.GetAll();


            return View(sessies);
        }

        public IActionResult SessieOverzicht(string id)
        {
            string aa = id;
            Sessie s = _sessieRepository.GetBySessieCode(id);
            return View(s);
        }


    }
}