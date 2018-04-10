using System;
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
        public Groepsbewerking Groepsbewerking { get; set; } // MOET OOK UIT BOX 
        public int FoutePogingen { get; set; }
        public DateTime StartTijd { get; set; }

        public Opdracht()
        {
        }

        public Opdracht(int volgNr, Actie actie, Oefening oefening, Toegangscode toegangscode, Groepsbewerking groepsbewerking)
        {
            VolgNr = volgNr;
            Actie = actie;
            Oefening = oefening;
            Toegangscode = toegangscode;
            Groepsbewerking = groepsbewerking;
        }
        
        public bool IsOpgelost(string antwoordVanGroep)
        {
            if(antwoordVanGroep == Oefening.AntwoordMetGroepsbewerking())
                return true;
            return false;
        }

        public void VerwerkAntwoord(double inputantwoord)
        {

        }
    }
}