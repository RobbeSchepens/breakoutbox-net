using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BreakOutBox.Models.Domain;
using Microsoft.AspNet.Identity;

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
            string[] tokens = User.Identity.GetUserName().Split('_');
            int index = tokens[1].LastIndexOf("@");
            if (index > 0)
                tokens[1] = tokens[1].Substring(0, index);


            Leerkracht lk = _leerkrachtRepository.GetByVolledigeNaam(tokens[0], tokens[1]); // de leerkreacht die vebonden staat met de huidige user
            List<Sessie> sessiesVanLeerkracht = lk.Sessies.ToList();

            ViewData["LeerkrachtNaam"] = lk.Voornaam + " " + lk.Achternaam;

            return View(sessiesVanLeerkracht);
        }

        public IActionResult OverzichtGroepenInSessie(string id)
        {

            

            return View(_sessieRepository.GetBySessieCode(id));
        }

        //public IActionResult ActiveerSessie(Sessie sessie)
        //{
        //    sessie.Activeer();
        //    return RedirectToAction(nameof(OverzichtGroepenInSessie));
        //}

    }
}
