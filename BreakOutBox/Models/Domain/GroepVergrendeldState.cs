using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class GroepVergrendeldState : GroepState
    {
        public GroepVergrendeldState(Groep groep) : base(groep)
        {
        }

        public override void ZetGereed()
        {
            throw new Exception("Deze groep is vergrendeld en kan niet gereed gezet worden.");
        }

        public override void ZetNietGereed()
        {
            throw new Exception("Deze groep is vergrendeld en kan niet niet-gereed gezet worden.");
        }

        public override void Vergrendel()
        {
            throw new Exception("Deze groep is al vergrendeld.");
        }

        public override void Ontgrendel()
        {
            this._groep.SwitchState(1);
        }
    }
}
