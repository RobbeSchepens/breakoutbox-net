using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Opdracht
    {
        public int OpdrachtId { get; set; }
        public int VolgNr { get; set; }
        public ICollection<Oefening> Oefeningen { get; set; }
        public int Toegangscode { get; set; } // Deze komt uit de box = het Java spel

        public Opdracht()
        {
        }

        public Opdracht(int volgNr, ICollection<Oefening> oefeningen, int toegangscode)
        {
            this.VolgNr = volgNr;
            this.Oefeningen = oefeningen;
            this.Toegangscode = toegangscode;
        }
    }
}