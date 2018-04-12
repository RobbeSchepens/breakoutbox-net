using System;

namespace BreakOutBox.Models.Domain
{
    public class GroepGeblokkeerdState : GroepState
    {
        public override string Beschrijving { get; set; }

        public GroepGeblokkeerdState(Groep groep) : base(groep)
        {
            Beschrijving = "geblokkeerd";
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
            throw new Exception("De groep is al geblokkeerd.");
        }

        public override void Deblokkeer()
        {
            _groep.State = 3;
            _groep.Pad.GetCurrentOpdracht().FoutePogingen = 0;
            _groep.Pad.GetCurrentOpdracht().StartTijd = DateTime.Now;
        }

        public override void ZetInSpel()
        {
            throw new Exception("De groep zit al in het spel.");
        }

        public override void HaalUitSpel()
        {
            throw new Exception("De groep kan niet uit het spel gehaald worden omdat ze geblokkeerd is.");
        }

        public override void VerwerkAntwoord(string inputantwoord)
        {
            throw new Exception("Jouw groepje is momenteel geblokkeerd en kan geen nieuwe antwoorden verwerken.");
        }

        public override void VerwerkToegangscode(string inputcode)
        {
            throw new Exception("Jouw groepje is momenteel geblokkeerd en kan geen nieuwe toegangscode verwerken.");
        }

        public override void StartVolgendeOpdracht()
        {
            throw new Exception("Jouw groepje is momenteel geblokkeerd en kan geen volgende opdracht starten.");
        }
    }
}
