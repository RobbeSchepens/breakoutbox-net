using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;

namespace BreakOutBox.Filters
{
    [AttributeUsageAttribute(AttributeTargets.All, AllowMultiple = false)]
    public class SessieFilter : ActionFilterAttribute
    {
        private readonly ISessieRepository _sessieRepository;
        private Sessie _sessie;

        public SessieFilter(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                _sessie = _sessieRepository.GetBySessieCode(ReadSessieFromSession(context.HttpContext));
            }
            catch (NullReferenceException)
            {
                throw new Exception("Er is geen sessiecode in de Session varaiabele.");
            }
            context.ActionArguments["sessie"] = _sessie;
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            WriteSessieToSession(_sessie, context.HttpContext);
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
    }
}
