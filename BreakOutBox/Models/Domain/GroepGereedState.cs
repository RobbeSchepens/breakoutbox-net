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
            this._groep.SwitchState(0);
        }

        public override void Vergrendel()
        {
            this._groep.SwitchState(2);
        }

        public override void Ontgrendel()
        {
            throw new Exception("De groep is niet vergrendeld.");
        }
    }
}
