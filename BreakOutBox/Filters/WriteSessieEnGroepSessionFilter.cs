using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace BreakOutBox.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class WriteSessieEnGroepSessionFilter : ActionFilterAttribute
    {
        private readonly ISessieRepository _sessieRepository;
        private Sessie _sessie;
        private Groep _groep;

        public WriteSessieEnGroepSessionFilter(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Wanneer een argument "sessiecode" wordt gegeven aan de action method
            if (context.ActionArguments["SessieCode"] != null)
            {
                // Sessieobject opvragen uit repository
                _sessie = _sessieRepository.GetBySessieCode(context.ActionArguments["SessieCode"].ToString());
                if (_sessie != null)
                {
                    // Cookie toewijzen
                    context.HttpContext.Session.SetString("sessiecode", JsonConvert.SerializeObject(_sessie.Code));
                }
            }

            // Wanneer een argument "groepid" wordt gegeven aan de action method
            if (context.ActionArguments["groepid"] != null)
            {
                // Groepobject opvragen uit repository
                _groep = _sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(context.ActionArguments["groepid"].ToString()));
                if (_groep != null)
                {
                    // Cookie toewijzen
                    context.HttpContext.Session.SetString("groepid", JsonConvert.SerializeObject(_groep.GroepId));
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
