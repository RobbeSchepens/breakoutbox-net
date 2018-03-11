using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public abstract class SessieState
    {
        protected Sessie sessie;

        protected SessieState(Sessie sessie)
        {
            this.sessie = sessie;
        }
        
        public abstract void Activeer();
        public abstract void Deactiveer(ICollection<Groep> groepen);
        public abstract void StartSpel(ICollection<Groep> groepen);
    }
}
