using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class SessionStartedState : SessieState
    {
        public SessionStartedState(Sessie sessie) : base(sessie)
        {

        }
    }
}
