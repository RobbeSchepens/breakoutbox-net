﻿using System;

namespace BreakOutBox.Models.Domain
{
    public class GroepVergrendeldState : GroepState
    {
        public override string Beschrijving { get; set; }

        public GroepVergrendeldState(Groep groep) : base(groep)
        {
            Beschrijving = "vergrendeld";
        }

        public override void ZetGekozen()
        {
            throw new Exception("De kan niet op gekozen gezet worden omdat ze vergrendeld is.");
        }

        public override void ZetNietGekozen()
        {
            throw new Exception("De kan niet op niet-gekozen gezet worden omdat ze vergrendeld is.");
        }

        public override void Vergrendel()
        {
            throw new Exception("De groep is al vergrendeld.");
        }

        public override void Ontgrendel()
        {
            _groep.State = 0;
        }

        public override void Blokkeer()
        {
            throw new Exception("De groep kan niet geblokkeerd worden omdat ze niet in de in-spel-staat is.");
        }

        public override void Deblokkeer()
        {
            throw new Exception("De groep kan niet gedeblokkeerd worden omdat ze niet geblokkeerd is.");
        }

        public override void ZetInSpel()
        {
            throw new Exception("De groep kan niet in het spel gezet worden omdat ze vergrendeld is.");
        }

        public override void HaalUitSpel()
        {
            throw new Exception("De groep kan niet uit het spel gehaald worden omdat ze niet in de in-spel-staat is.");
        }
    }
}
