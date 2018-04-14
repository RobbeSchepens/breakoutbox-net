using System;

namespace BreakOutBox.Models.Domain
{
    public class SessieActiefState : SessieState
    {
        public override string Beschrijving { get; set; }

        public SessieActiefState(Sessie sessie) : base(sessie)
        {
            Beschrijving = "Actief";
        }

        public override void Activeer()
        {
            throw new StateException("De sessie is al actief.");
        }

        public override void Deactiveer()
        {
            _sessie.State = 0;
        }

        public override void StartSpel()
        {
            _sessie.State = 2;
        }

        public override void HaalUitSpel()
        {
            throw new StateException("Het spel is niet in de in-spel-state.");
        }

        public override void Blokkeer()
        {
            throw new StateException("De sessie kan niet geblokkeerd worden omdat ze niet in de in-spel-state is.");
        }

        public override void Deblokkeer()
        {
            throw new StateException("De sessie kan niet gedeblokkeerd worden omdat ze niet geblokkeerd is.");
        }
    }
}
