using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace BreakOutBox.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class ClearSessieSessionFilter : ActionFilterAttribute
    {
        public ClearSessieSessionFilter()
        {
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Session.Remove("sessiecode");
            base.OnActionExecuted(context);
        }
    }
}
