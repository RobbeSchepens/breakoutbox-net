using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace BreakOutBox.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class LeerkrachtFilter : ActionFilterAttribute
    {
        private readonly ILeerkrachtRepository _leerkrachtRepository;

        public LeerkrachtFilter(ILeerkrachtRepository leerkrachtRepository)
        {
            _leerkrachtRepository = leerkrachtRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments["leerkracht"] =
                context.HttpContext.User.Identity.IsAuthenticated ?
                _leerkrachtRepository.GetByEmail(context.HttpContext.User.Identity.Name) : null;
            base.OnActionExecuting(context);
        }
    }
}
