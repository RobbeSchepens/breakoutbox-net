using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class NotReadyState : SessieState
    {
        public NotReadyState(Sessie sessie) : base(sessie)
        {

        }
    }
}
