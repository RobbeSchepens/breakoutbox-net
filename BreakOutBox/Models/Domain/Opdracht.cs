using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Opdracht
    {
        public int OpdrachtId { get; set; }
        public int VolgNr { get; set; }
        public bool Opgelost { get; set; }
        public Actie Actie { get; set; } // UIT BOX
        public Oefening Oefening { get; set; } // UIT BOX
        public Toegangscode Toegangscode { get; set; } // UIT BOX
        public int foutePogingen { get; set; }


        public Opdracht()
        {

        }
        public Opdracht(int volgNr, Actie actie, Oefening oefening, Toegangscode toegangscode)
        {
            VolgNr = volgNr;
            Actie = actie;
            Oefening = oefening;
            Toegangscode = toegangscode;
            Opgelost = false;
        }
        


        public bool isOpgelost(string antwoordVanGroep)
        {
            if(antwoordVanGroep == Oefening.Antwoord.ToString())
            {
                
                return true;
            }
            return false;
        }
    }
}