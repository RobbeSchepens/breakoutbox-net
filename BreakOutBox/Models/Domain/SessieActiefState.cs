using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class SessieActiefState : SessieState
    {
        public SessieActiefState(Sessie sessie) : base(sessie)
        {
        }

        public string Deactiveer()
        {
            return "Sessie is gedeactiveerd.";
        }

        public string StartSpel()
        {
            return "Spel is gestart.";
        }
    }
}
