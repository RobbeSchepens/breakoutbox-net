using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class SessieNonActiefState : SessieState
    {
        public SessieNonActiefState(Sessie sessie) : base(sessie)
        {
        }

        public string Activeer()
        {
            return "Sessie is geactiveerd. Groepen kunnen nu deelnemen.";
        }
    }
}
