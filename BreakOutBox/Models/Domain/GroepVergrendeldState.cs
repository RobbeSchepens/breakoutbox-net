using System;

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
            throw new StateException("De kan niet op gekozen gezet worden omdat ze vergrendeld is.");
        }

        public override void ZetNietGekozen()
        {
            throw new StateException("De kan niet op niet-gekozen gezet worden omdat ze vergrendeld is.");
        }

        public override void Vergrendel()
        {
            throw new StateException("De groep is al vergrendeld.");
        }

        public override void Ontgrendel()
        {
            _groep.State = 0;
        }

        public override void Blokkeer()
        {
            throw new StateException("De groep kan niet geblokkeerd worden omdat ze niet in de in-spel-staat is.");
        }

        public override void Deblokkeer()
        {
            throw new StateException("De groep kan niet gedeblokkeerd worden omdat ze niet geblokkeerd is.");
        }

        public override void ZetInSpel()
        {
            throw new StateException("De groep kan niet in het spel gezet worden omdat ze vergrendeld is.");
        }

        public override void HaalUitSpel()
        {
            throw new StateException("De groep kan niet uit het spel gehaald worden omdat ze niet in de in-spel-staat is.");
        }

        public override void VerwerkAntwoord(string inputantwoord)
        {
            throw new StateException("Er kan geen antwoord verwerkt worden omdat de groep vergrendeld is.");
        }

        public override void VerwerkToegangscode(string inputcode)
        {
            throw new StateException("Er kan geen toegangscode verwerkt worden omdat de groep vergrendeld is.");
        }

        public override void StartVolgendeOpdracht()
        {
            throw new StateException("De volgende opdracht kan niet gestart worden omdat de groep vergrendeld is.");
        }
    }
}
