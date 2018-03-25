﻿using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace BreakOutBox.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class GroepSessionFilter : ActionFilterAttribute
    {
        private readonly ISessieRepository _sessieRepository;
        private Sessie _sessie;
        private Groep _groep;
        private string _groepid;

        public GroepSessionFilter(ISessieRepository sessieRepository)
        {
            _sessieRepository = sessieRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _groepid = Convert.ToString(context.ActionArguments["groepid"]);

            if (ReadSessieFromSession(context.HttpContext) == null)
                throw new Exception("Er is geen sessiecode in de Session variabele.");
            else
            {
                _sessie = _sessieRepository.GetBySessieCode(ReadSessieFromSession(context.HttpContext));
                _sessie.SwitchState(_sessie.State);
                context.ActionArguments["sessie"] = _sessie;

                if (ReadGroepFromSession(context.HttpContext) == null)
                    _groep = null;
                //throw new Exception("Er is geen groepid in de Session variabele.");
                else
                {
                    _groep = _sessie.Groepen.FirstOrDefault(g => g.GroepId == Int32.Parse(ReadGroepFromSession(context.HttpContext)));
                    _groep.SwitchState(_groep.State);
                    context.ActionArguments["groep"] = _groep;
                }
            }

            WriteGroepToSession(_groepid, context.HttpContext);
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

        private void WriteGroepToSession(string groepid, HttpContext context)
        {
            context.Session.SetString("sessiecode", JsonConvert.SerializeObject(groepid));
        }
    }
}
