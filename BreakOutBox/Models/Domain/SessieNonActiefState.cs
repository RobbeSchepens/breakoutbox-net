using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class SessieNonActiefState : SessieState
    {
        public override string Beschrijving { get; set; }

        public SessieNonActiefState(Sessie sessie) : base(sessie)
        {
            Beschrijving = "Inactief";
        }

        public override void Activeer()
        {
            _sessie.State = 1;
        }

        public override void Deactiveer()
        {
            throw new StateException("De sessie is al non-actief.");
        }

        public override void StartSpel()
        {
            throw new StateException("Het spel kan niet gestart worden als de sessie niet actief is.");
        }

        public override void HaalUitSpel()
        {
            throw new StateException("Het spel is niet in de in-spel-state.");
        }

        public override void Blokkeer(ICollection<Groep> groepen)
        {
            throw new StateException("Sessie is niet actief!");
        }

        public override void Deblokkeer(ICollection<Groep> groepen)
        {
            throw new StateException("Sessie is niet geblokkeerd!");
        }
    }
}