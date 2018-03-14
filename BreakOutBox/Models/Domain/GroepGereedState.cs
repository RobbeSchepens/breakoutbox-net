using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class GroepGereedState : GroepState
    {
        public GroepGereedState(Groep groep) : base(groep)
        {
        }

        public override void ZetGereed()
        {
            throw new Exception("De groep is al gereed.");
        }

        public override void ZetNietGereed()
        {
            // ...
        }

        public override void Vergrendel()
        {
            // ...
        }

        public override void Ontgrendel()
        {
            throw new Exception("De groep is niet vergrendeld.");
        }
    }
}
