using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace BreakOutBox.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class SessieFilter : ActionFilterAttribute
    {
        private readonly ISessieRepository _sessieRepository;
        private Sessie _sessie;
        private Groep _groep;

        public SessieFilter(ISessieRepository sessieRepository)
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
                context.ActionArguments["sessie"] = _sessie;

                if (ReadGroepFromSession(context.HttpContext) == null)
                    _groep = null;
                //throw new Exception("Er is geen groepid in de Session variabele.");
                else
                {
                    _groep = _sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(ReadGroepFromSession(context.HttpContext)));
                    context.ActionArguments["groep"] = _groep;
                }
            }
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            WriteSessieToSession(_sessie, context.HttpContext);
            WriteGroepToSession(_groep, context.HttpContext);
            base.OnActionExecuted(context);
        }

        private string ReadSessieFromSession(HttpContext context)
        {
            string sessiecode = context.Session.GetString("sessie") == null ?
                null : JsonConvert.DeserializeObject<string>(context.Session.GetString("sessie"));
            return sessiecode;
        }

        private void WriteSessieToSession(Sessie sessie, HttpContext context)
        {
            context.Session.SetString("sessie", JsonConvert.SerializeObject(sessie.Code));
        }

        private string ReadGroepFromSession(HttpContext context)
        {
            string groepid = context.Session.GetString("groep") == null ?
                null : JsonConvert.DeserializeObject<string>(context.Session.GetString("sessie"));
            return groepid;
        }

        private void WriteGroepToSession(Groep groep, HttpContext context)
        {
            context.Session.SetString("groep", JsonConvert.SerializeObject(groep.GroepId));
        }
    }
}
