using System;

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
        public abstract void Deactiveer();
        public abstract void StartSpel();
        public abstract void HaalUitSpel();
        public abstract void Blokkeer();
        public abstract void Deblokkeer();
    }
}
