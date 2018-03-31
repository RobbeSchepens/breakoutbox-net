using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public abstract class SessieState
    {
        protected Sessie _sessie;

        public abstract string Beschrijving { get; set; }

        protected SessieState(Sessie sessie)
        {
            _sessie = sessie;
        }
        
        public abstract void Activeer();
        public abstract void Deactiveer(ICollection<Groep> groepen);
        public abstract void StartSpel(ICollection<Groep> groepen);
        public abstract void Blokkeer();
        public abstract void Deblokkeer();
    }
}
