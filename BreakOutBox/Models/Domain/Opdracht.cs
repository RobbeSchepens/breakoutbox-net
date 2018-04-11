using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Opdracht
    {
        public int OpdrachtId { get; set; }
        public int VolgNr { get; set; }
        public bool IsOpgelost { get; set; }
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
        
        //public bool IsOpgelost(string antwoordVanGroep)
        //{
        //    //if(antwoordVanGroep == Oefening.AntwoordMetGroepsbewerking())
        //    //    return true;
        //    //return false;
        //}

        public void VerwerkAntwoord(double inputantwoord)
        {
            double? correctAntwoord = null;

            switch (Groepsbewerking.Bewerking)
            {
                case EnumBewerking.OPTELLING:
                    correctAntwoord = Oefening.Antwoord + Groepsbewerking.Getal; break;
                case EnumBewerking.AFTREKKING:
                    correctAntwoord = Oefening.Antwoord - Groepsbewerking.Getal; break;
                case EnumBewerking.VERMENIGVULDIGING:
                    correctAntwoord = Oefening.Antwoord * Groepsbewerking.Getal; break;
                case EnumBewerking.DELING:
                    correctAntwoord = Oefening.Antwoord / Groepsbewerking.Getal; break;
            }

            if (correctAntwoord == null)
                throw new Exception("Systeemfout! Het juiste antwoord kon niet berekend worden.");

            if (inputantwoord != correctAntwoord)
            {
                FoutePogingen++;
                if (FoutePogingen == 3)
                    throw new FoutePogingenException("Je hebt 3 foute pogingen");
            }
        }

        public void VerwerkToegangscode(double inputcode)
        {
            if (inputcode != Toegangscode.Code)
                throw new FouteToegangscodeException("Je hebt een foute toegangscode opgegeven.");
            IsOpgelost = true;
        }
    }
}