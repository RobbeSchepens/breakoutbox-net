using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace BreakOutBox.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class SessieSessionFilter : ActionFilterAttribute
    {
        private readonly ISessieRepository _sessieRepository;
        private Sessie _sessie;

        public SessieSessionFilter(ISessieRepository sessieRepository)
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
            }
            base.OnActionExecuting(context);
        }

        private string ReadSessieFromSession(HttpContext context)
        {
            return JsonConvert.DeserializeObject<string>(context.Session.GetString("sessiecode"));
        }
    }
}
