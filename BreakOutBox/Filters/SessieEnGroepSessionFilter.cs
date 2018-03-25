using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace BreakOutBox.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class SessieEnGroepSessionFilter : ActionFilterAttribute
    {
        private readonly ISessieRepository _sessieRepository;
        private Sessie _sessie;
        private Groep _groep;

        public SessieEnGroepSessionFilter(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (ReadSessieFromSession(context.HttpContext) != null)
            {
                // Sessieobject opvragen uit repository aan de hand van cookie "sessiecode".
                _sessie = _sessieRepository.GetBySessieCode(ReadSessieFromSession(context.HttpContext));
                _sessie.SwitchState(_sessie.State);

                // Deze switchstate dient om de _currentState van elke groep goed te zetten. 
                // Staat ook in de setter van Groep.State maar doet niet zijn ding.
                foreach (Groep groep in _sessie.Groepen)
                {
                    groep.SwitchState(groep.State);
                }

                // Toekennen aan argumenten van de action method. Vang je op via (Sessie sessie). 
                context.ActionArguments["sessie"] = _sessie;

                // Check of de cookie "groepid" leeg is.
                if (ReadGroepFromSession(context.HttpContext) != null)
                {
                    // Gekozen groepobject halen uit sessie.
                    _groep = _sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(ReadGroepFromSession(context.HttpContext)));
                    _groep.SwitchState(_groep.State);

                    // Toekennen aan argumenten van de action method.
                    context.ActionArguments["groep"] = _groep;
                }
            }
            base.OnActionExecuting(context);
        }

        private string ReadSessieFromSession(HttpContext context)
        {
            string sessiecode = context.Session.GetString("sessiecode") == null ?
                   null : JsonConvert.DeserializeObject<string>(context.Session.GetString("sessiecode"));
            return sessiecode;
        }

        private string ReadGroepFromSession(HttpContext context)
        {
            string groepid = context.Session.GetString("groepid") == null ?
                null : JsonConvert.DeserializeObject<string>(context.Session.GetString("groepid"));
            return groepid;
        }

        private void WriteGroepToSession(Groep groep, HttpContext context)
        {
            context.Session.SetString("groepid", JsonConvert.SerializeObject(groep.GroepId));
        }
    }
}
