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

        public IActionResult GeefSessieCode(string SessieCode)
        {


            return View();
        }


    }
}