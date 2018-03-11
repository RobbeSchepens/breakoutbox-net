using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class GroepNietGereedState : GroepState
    {
        public GroepNietGereedState(Groep groep) : base(groep)
        {
        }

        public override void ZetGereed()
        {
            // ...
        }

        public override void ZetNietGereed()
        {
            throw new Exception("De groep is al niet-gereed.");
        }
    }
}
