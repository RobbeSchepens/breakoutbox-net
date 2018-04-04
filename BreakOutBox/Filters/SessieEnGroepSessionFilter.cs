using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
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
            TakeArgumentAndWriteToSession(context, "sessiecode");

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

                IsSessieNonActief(context);
                TakeArgumentAndWriteToSession(context, "groepid");

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
                else
                    context.ActionArguments["groep"] = null;
            }
            else
                context.ActionArguments["sessie"] = null;

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

        private void TakeArgumentAndWriteToSession(ActionExecutingContext context, string sessionkey)
        {
            object obj;
            context.ActionArguments.TryGetValue(sessionkey, out obj);

            if (obj != null && sessionkey == "sessiecode")
            {
                _sessie = _sessieRepository.GetBySessieCode(obj.ToString());
                if (_sessie != null)
                    context.HttpContext.Session.SetString(sessionkey, JsonConvert.SerializeObject(obj));
            }

            if (obj != null && sessionkey == "groepid")
            {
                _groep = _sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(obj.ToString()));
                if (_groep != null)
                    context.HttpContext.Session.SetString(sessionkey, JsonConvert.SerializeObject(obj));
            }
        }

        private void IsSessieNonActief(ActionExecutingContext context)
        {
            if (_sessie.CurrentState is SessieNonActiefState && !context.HttpContext.User.Identity.IsAuthenticated)
            {
                ((Controller)context.Controller).TempData.Add("info", "Deze sessie is niet geactiveerd.");
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary {{ "Controller", "Home" },
                                      { "Action", "Index" } });
            }
        }
    }
}
