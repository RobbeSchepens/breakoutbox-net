using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace BreakOutBox.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class SessieDeelnemenFilter : ActionFilterAttribute
    {
        private readonly ISessieRepository _sessieRepository;
        private string _sessiecode;
        private Sessie _sessie;

        public SessieDeelnemenFilter(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _sessiecode = Convert.ToString(context.ActionArguments["SessieCode"]);

            _sessie = _sessieRepository.GetBySessieCode(_sessiecode);
            if (_sessie == null)
                throw new Exception("Sessie niet gevonden.");
            else
                context.ActionArguments["sessie"] = _sessie;

            WriteSessieToSession(_sessiecode, context.HttpContext);
            base.OnActionExecuting(context);
        }

        private void WriteSessieToSession(string sessiecode, HttpContext context)
        {
            context.Session.SetString("sessiecode", JsonConvert.SerializeObject(sessiecode));
        }
    }
}
