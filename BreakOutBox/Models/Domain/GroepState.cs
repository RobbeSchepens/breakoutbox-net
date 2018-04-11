using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public abstract class GroepState
    {
        protected Groep _groep;

        public abstract string Beschrijving { get; set; }

        protected GroepState(Groep groep)
        {
            _groep = groep;
        }

        public abstract void ZetGekozen();
        public abstract void ZetNietGekozen();
        public abstract void Vergrendel();
        public abstract void Ontgrendel();
        public abstract void Blokkeer();
        public abstract void Deblokkeer();
        public abstract void ZetInSpel();
        public abstract void HaalUitSpel();
        public abstract void VerwerkAntwoord(double inputantwoord);
        public abstract void VerwerkToegangscode(double inputcode);
        public abstract void StartVolgendeOpdracht();
    }
}
