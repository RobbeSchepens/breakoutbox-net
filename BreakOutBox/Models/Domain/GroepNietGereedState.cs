using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class GroepNietGereedState : GroepState
    {
        public override string Beschrijving { get; set; }

        public GroepNietGereedState(Groep groep) : base(groep)
        {
            Beschrijving = "nog niet gekozen";
        }

        public override void ZetGereed()
        {
            _groep.State = 1;
        }

        public override void ZetNietGereed()
        {
            throw new Exception("De groep is al niet-gereed.");
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
            throw new Exception("De groep is nog niet klaar.");
        }

        public override void DeBlokkeer()
        {
            throw new Exception("De groep is niet geblokkeerd.");
        }
    }
}
