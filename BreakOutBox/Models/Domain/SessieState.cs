using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public abstract class SessieState
    {
        protected Sessie sessie;

        public SessieState(Sessie sessie)
        {
            this.sessie = sessie;
        }

        public virtual string Activeer() {

            return "De sessie moet deactief zijn om ze te kunnen activeren.";
        }

        public string Deactiveer()
        {
            return "De sessie moet actief zijn om ze te kunnen deactiveren.";
        }

        public string StartSpel()
        {
            return "Het spel moet eerst geactiveerd zijn en alle groepen klaar.";
        }
    }
}
