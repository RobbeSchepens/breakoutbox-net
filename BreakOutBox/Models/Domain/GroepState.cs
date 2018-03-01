using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public abstract class GroepState
    {
        protected Groep groep;

        public GroepState(Groep groep)
        {
            this.groep = groep;
        }

        public void Vergrendel()
        {
            groep.Vergrendel();
        }

        public void VoegLeerlingToe(Leerling leerling)
        {
            groep.VoegLeerlingToe(leerling);
        }
    }
}
