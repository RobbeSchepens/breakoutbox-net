using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class SessieInSpel : SessieState
    {
        public SessieInSpel(Sessie sessie) : base(sessie)
        {
        }

        public string Deactiveer()
        {
            return "Spel is beeindigd en sessie gedeactiveerd.";
        }
    }
}
