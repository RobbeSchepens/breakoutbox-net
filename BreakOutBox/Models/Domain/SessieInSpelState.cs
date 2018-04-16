using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class SessieInSpelState : SessieState
    {
        public override string Beschrijving { get; set; }

        public SessieInSpelState(Sessie sessie) : base(sessie)
        {
            Beschrijving = "In spel";
        }

        public override void Activeer()
        {
            throw new StateException("Gebruik de haal uit spel knop hiervoor.");
        }

        public override void Deactiveer()
        {
            _sessie.State = 0;
        }

        public override void StartSpel()
        {
            throw new StateException("Het spel is al gestart.");
        }

        public override void HaalUitSpel()
        {
            _sessie.State = 1;
        }

        public override void Blokkeer(ICollection<Groep> groepen)
        {
            _sessie.State = 3;
            foreach (Groep groep in groepen)
                groep.Pad.GetCurrentOpdracht().StopOpdracht();
        }

        public override void Deblokkeer(ICollection<Groep> groepen)
        {
            throw new StateException("De sessie kan niet gedeblokkeerd worden omdat ze niet geblokkeerd is.");
        }
    }
}
