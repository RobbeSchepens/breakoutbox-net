using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class GroepGereedState : GroepState
    {
        public override string Beschrijving { get; set; }

        public GroepGereedState(Groep groep) : base(groep)
        {
            Beschrijving = "Klaar";
        }

        public override void ZetGereed()
        {
            throw new Exception("De groep is al gereed.");
        }

        public override void ZetNietGereed()
        {
            _groep.State = 0;
        }

        public override void Vergrendel()
        {
            _groep.State = 2;
        }

        public override void Ontgrendel()
        {
            throw new Exception("De groep is niet vergrendeld.");
        }

        public override void Blokkeer()
        {
            throw new Exception("De groep is nog niet vergrendeld.");
        }

        public override void DeBlokkeer()
        {
            throw new Exception("De groep is niet geblokkeerd.");
        }
    }
}
