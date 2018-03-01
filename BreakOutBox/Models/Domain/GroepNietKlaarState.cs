using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class GroepNietKlaarState : GroepState
    {
        public GroepNietKlaarState(Groep groep) : base(groep)
        {

        }

        public void VoegLeerlingToe(Leerling leerling)
        {
            base.VoegLeerlingToe(leerling);
        }
    }
}
