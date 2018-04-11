using System;

namespace BreakOutBox.Models.Domain
{
    public class GroepInSpelState : GroepState
    {
        public override string Beschrijving { get; set; }

        public GroepInSpelState(Groep groep) : base(groep)
        {
            Beschrijving = "in spel";
        }

        public override void ZetGekozen()
        {
            throw new Exception("De groep is in de in-spel-staat en kan niet op gekozen gezet worden.");
        }

        public override void ZetNietGekozen()
        {
            throw new Exception("De groep is in de in-spel-staat en kan niet op niet-gekozen gezet worden.");
        }

        public override void Vergrendel()
        {
            throw new Exception("De groep kan niet vergrendeld worden omdat ze in de in-spel-staat is.");
        }

        public override void Ontgrendel()
        {
            throw new Exception("De groep kan niet ontgrendeld worden omdat ze niet vergrendeld is.");
        }

        public override void Blokkeer()
        {
            _groep.State = 4;
        }

        public override void Deblokkeer()
        {
            throw new Exception("De groep kan niet gedeblokkeerd worden omdat ze niet geblokkeerd is.");
        }

        public override void ZetInSpel()
        {
            throw new Exception("De groep zit al in het spel.");
        }

        public override void HaalUitSpel()
        {
            _groep.State = 1;
        }

        public override void VerwerkAntwoord(double inputantwoord)
        {
            _groep.Pad.GetCurrentOpdracht().VerwerkAntwoord(inputantwoord);
        }

        public override void VerwerkToegangscode(double inputcode)
        {
            _groep.Pad.GetCurrentOpdracht().VerwerkToegangscode(inputcode);
        }

        public override void StartVolgendeOpdracht()
        {
            _groep.Pad.GetCurrentOpdracht().StartVolgendeOpdracht();
        }
    }
}
