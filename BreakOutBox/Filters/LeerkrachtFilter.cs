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
            Leerkracht lk;

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                // Leerkracht opvragen via Identity Name
                lk = _leerkrachtRepository.GetByEmail(context.HttpContext.User.Identity.Name);
                
                // Deze switchstate dient om de _currentState van elke groep goed te zetten. 
                // Staat ook in de setter van Groep.State maar doet niet zijn ding.
                foreach (Sessie sessie in lk.Sessies)
                {
                    sessie.SwitchState(sessie.State);
                    foreach (Groep groep in sessie.Groepen)
                    {
                        groep.SwitchState(groep.State);
                    }
                }

                context.ActionArguments["leerkracht"] = lk;
            }

            base.OnActionExecuting(context);
        }
    }
}
