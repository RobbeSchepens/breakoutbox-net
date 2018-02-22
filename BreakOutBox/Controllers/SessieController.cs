using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakOutBox.Models.Domain;
using BreakOutBox.Models.SessieViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BreakOutBox.Controllers
{
    public class SessieController : Controller
    {
        private readonly ISessieRepository _sessieRepository;
        private readonly IGroepRepository _groepRepository;
        private readonly IOpdrachtRepository _opdrachtRepository;
        private Sessie s = null;

        public SessieController(ISessieRepository sessieRepository, IGroepRepository groepRepository, IOpdrachtRepository opdrachtRepository)
        {
            _groepRepository = groepRepository;
            _sessieRepository = sessieRepository;
            _opdrachtRepository = opdrachtRepository;
        }

        // GET: /<controller>/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SessieOverzicht(int id)
        {
            s = _sessieRepository.GetByCode(id.ToString());
            _groepRepository.GetAll();
            _opdrachtRepository.GetAll();

            var vm = new ToonGroepenInSessieViewModel()
            {
                HuidigeSessieCode = s.UniekeCode,
                GroepenInSessie = s.Groepen
            };

            return View(vm);
        }

        public ActionResult ToonOpdracht(int id)
        {
            Sessie s = _sessieRepository.GetByCode("321"); // Dit moet automatisch doorgegeven worden door iets
            _groepRepository.GetAll();

            var vm = new ToonOpdrachtViewModel()
            {
            };
            //hier view model met opdrachten in juiste volgorde
            return View(vm);
        }
    }
}