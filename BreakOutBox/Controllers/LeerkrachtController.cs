using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BreakOutBox.Models.Domain;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BreakOutBox.Controllers
{
    public class LeerkrachtController : Controller
    {
        // GET: /<controller>/
        private readonly ISessieRepository _sessieRepository;
        private readonly ILeerkrachtRepository _leerkrachtRepository;
        public LeerkrachtController(ISessieRepository sessieRepository, ILeerkrachtRepository leerkrachtRepository)
        {
            _sessieRepository = sessieRepository;
            _leerkrachtRepository = leerkrachtRepository;

        }

        public IActionResult Index()
        {


            Leerkracht lk = _leerkrachtRepository.GetByVolledigeNaam("Tom", "Deveylder"); // de leerkreacht die vebonden staat met de huidige user
            List<Sessie> sessiesVanLeerkracht = _sessieRepository.GetSessiesByLeerkracht(lk).ToList();

            ViewData["LeerkrachtNaam"] = lk.Voornaam + " " + lk.Achternaam; 

            return View(sessiesVanLeerkracht);
        }

        public IActionResult OverzichtGroepenInSessie(string id)
        {

            

            return View(_sessieRepository.GetBySessieCode(id));
        }

    }
}
