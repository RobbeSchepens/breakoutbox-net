using System;

namespace BreakOutBox.Models.Domain
{
    public class GroepNietGekozenState : GroepState
    {
        public override string Beschrijving { get; set; }

        public GroepNietGekozenState(Groep groep) : base(groep)
        {
            Beschrijving = "nog niet gekozen";
        }

        public override void ZetGekozen()
        {
            _groep.State = 1;
        }

        public override void ZetNietGekozen()
        {
            throw new Exception("De groep staat al op niet-gekozen.");
        }

        public override void Vergrendel()
        {
            _groep.State = 2;
        }

        public override void Ontgrendel()
        {
            throw new Exception("De groep kan niet ontgrendeld worden omdat ze niet vergrendeld is.");
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
            throw new Exception("De groep kan niet in het spel gezet worden omdat ze niet gekozen is.");
        }

        public override void HaalUitSpel()
        {
            throw new Exception("De groep kan niet uit het spel gehaald worden omdat ze niet in de in-spel-staat is.");
        }

        public override void VerwerkAntwoord(string inputantwoord)
        {
            throw new Exception("Er kan geen antwoord verwerkt worden omdat de groep niet in de in-spel-state is.");
        }

        public override void VerwerkToegangscode(string inputcode)
        {
            throw new Exception("Er kan geen toegangscode verwerkt worden omdat de groep niet in de in-spel-state is.");
        }

        public override void StartVolgendeOpdracht()
        {
            throw new Exception("De volgende opdracht kan niet gestart worden omdat de groep niet in de in-spel-state is.");
        }
    }
}
