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
            if (ReadSessieFromSession(context.HttpContext) == null)
                throw new Exception("Er is geen sessiecode in de Session variabele.");
            else
            {
                _sessie = _sessieRepository.GetBySessieCode(ReadSessieFromSession(context.HttpContext));
                _sessie.SwitchState(_sessie.State);
                context.ActionArguments["sessie"] = _sessie;

                if (ReadGroepFromSession(context.HttpContext) != null)
                {
                    _groep = _sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(ReadGroepFromSession(context.HttpContext)));
                    _groep.SwitchState(_groep.State);
                    context.ActionArguments["groep"] = _groep;
                }
            }
            base.OnActionExecuting(context);
        }

        private string ReadSessieFromSession(HttpContext context)
        {
            return JsonConvert.DeserializeObject<string>(context.Session.GetString("sessiecode"));
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
