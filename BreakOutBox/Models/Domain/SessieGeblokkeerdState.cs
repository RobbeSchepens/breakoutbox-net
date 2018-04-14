using System;

namespace BreakOutBox.Models.Domain
{
    public class SessieGeblokkeerdState : SessieState
    {
        public override string Beschrijving { get; set; }

        public SessieGeblokkeerdState(Sessie sessie) : base(sessie)
        {
            Beschrijving = "Geblokkeerd";
        }

        public override void Activeer()
        {
            throw new StateException("De sessie kan niet geactiveerd worden omdat ze al in de in-spel-state is.");
        }

        public override void Deactiveer()
        {
            throw new StateException("De sessie kan niet gedeactiveerd worden omdat ze geblokkeerd is.");
        }

        public override void StartSpel()
        {
            throw new StateException("De sessie is al in de in-spel-state.");
        }

        public override void HaalUitSpel()
        {
            throw new StateException("De sessie kan niet uit het spel gehaald worden omdat ze geblokkeerd is.");
        }

        public override void Blokkeer()
        {
            throw new StateException("De sessie is al geblokkeerd.");
        }

        public override void Deblokkeer()
        {
            _sessie.State = 2;
        }
    }
}
