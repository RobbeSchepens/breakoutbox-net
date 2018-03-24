using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class GroepVergrendeldState : GroepState
    {
        public override string Beschrijving { get; set; }

        public GroepVergrendeldState(Groep groep) : base(groep)
        {
            Beschrijving = "Vergrendeld";
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
            _groep.State = 1;
        }

        public override void Blokkeer()
        {
            _groep.State = 3;
        }

        public override void DeBlokkeer()
        {
            throw new Exception("De groep is niet geblokkeerd.");
        }
    }
}
