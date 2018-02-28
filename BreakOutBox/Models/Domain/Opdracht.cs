using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Opdracht
    {
        public int OpdrachtId { get; set; }
        public int VolgNr { get; set; }
        public ICollection<Oefening> Oefeningen { get; set; }
        public int Toegangscode { get; set; } // Deze komt uit de box = het Java spel
        public Groepsbewerking GroepsBewerking { get; set; }

        public Opdracht()
        {
        }

        public Opdracht(int volgNr, int toegangscode)
        {
            VolgNr = volgNr;
            Oefeningen = new List<Oefening>();
            Toegangscode = toegangscode;
        }

        public void voegOefeningToe(Oefening oefening)
        {
            Oefeningen.Add(oefening);
        }
    }
}