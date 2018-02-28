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

        public void vergrendel()
        {
            groep.Vergrendel();
        }

        public void voegLeerlingToe(Leerling leerling)
        {
            groep.VoegLeerlingToe(leerling);
        }
    }
}
