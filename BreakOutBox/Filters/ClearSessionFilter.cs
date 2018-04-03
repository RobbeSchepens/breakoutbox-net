using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace BreakOutBox.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class ClearSessionFilter : ActionFilterAttribute
    {
        public ClearSessionFilter()
        {
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Session.Clear();
            base.OnActionExecuted(context);
        }
    }
}
