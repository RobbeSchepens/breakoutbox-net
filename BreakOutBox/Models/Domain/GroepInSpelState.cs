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
            throw new StateException("De groep is in de in-spel-staat en kan niet op gekozen gezet worden.");
        }

        public override void ZetNietGekozen()
        {
            throw new StateException("De groep is in de in-spel-staat en kan niet op niet-gekozen gezet worden.");
        }

        public override void Vergrendel()
        {
            throw new StateException("De groep kan niet vergrendeld worden omdat ze in de in-spel-staat is.");
        }

        public override void Ontgrendel()
        {
            throw new StateException("De groep kan niet ontgrendeld worden omdat ze niet vergrendeld is.");
        }

        public override void Blokkeer()
        {
            _groep.Pad.GetCurrentOpdracht().StopOpdracht();
            _groep.State = 4;
        }

        public override void Deblokkeer()
        {
            throw new StateException("De groep kan niet gedeblokkeerd worden omdat ze niet geblokkeerd is.");
        }

        public override void ZetInSpel()
        {
            throw new StateException("De groep zit al in het spel.");
        }

        public override void HaalUitSpel()
        {
            _groep.State = 1;
        }

        public override void VerwerkAntwoord(string inputantwoord)
        {
            _groep.Pad.GetCurrentOpdracht().VerwerkAntwoord(inputantwoord);
        }

        public override void VerwerkToegangscode(string inputcode)
        {
            _groep.Pad.VerwerkToegangscode(inputcode);
        }

        public override void StartVolgendeOpdracht()
        {
            _groep.Pad.StartVolgendeOpdracht();
        }
    }
}
