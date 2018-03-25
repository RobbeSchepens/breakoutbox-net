using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class GroepGeblokkeerdState : GroepState
    {
        public override string Beschrijving { get; set; }

        public GroepGeblokkeerdState(Groep groep) : base(groep)
        {
            Beschrijving = "geblokkeerd";
        }

        public override void ZetGereed()
        {
            throw new Exception("Groep is geblokkeerd!");
        }

        public override void ZetNietGereed()
        {
            throw new Exception("Groep is geblokkeerd!");
        }

        public override void Vergrendel()
        {
            throw new Exception("Groep is geblokkeerd!");
        }

        public override void Ontgrendel()
        {
            throw new Exception("Groep is geblokkeerd!");
        }

        public override void Blokkeer()
        {
            throw new Exception("Groep is al geblokkeerd!");
        }

        public override void DeBlokkeer()
        {
            _groep.State = 2;
        }
    }
}
