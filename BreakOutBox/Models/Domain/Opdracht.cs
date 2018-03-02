using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Opdracht
    {
        public int OpdrachtId { get; set; }
        public int VolgNr { get; set; }
        public Oefening Oefening { get; set; } //Komt uit box
        public Toegangscode Toegangscode { get; set; } // Deze komt uit de box = het Java spel

        public Opdracht(int volgNr, Toegangscode toegangscode, Oefening oefening)
        {
            VolgNr = volgNr;
            Oefening = oefening;
            Toegangscode = toegangscode;
        }
    }
}