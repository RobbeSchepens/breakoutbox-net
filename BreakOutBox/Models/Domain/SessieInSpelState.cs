using System;

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
            throw new Exception("Gebruik de haal uit spel knop hiervoor.");
        }

        public override void Deactiveer()
        {
            _sessie.State = 0;
        }

        public override void StartSpel()
        {
            throw new Exception("Het spel is al gestart.");
        }

        public override void HaalUitSpel()
        {
            _sessie.State = 1;
        }

        public override void Blokkeer()
        {
            _sessie.State = 3;
        }

        public override void Deblokkeer()
        {
            throw new Exception("De sessie kan niet gedeblokkeerd worden omdat ze niet geblokkeerd is.");
        }
    }
}
