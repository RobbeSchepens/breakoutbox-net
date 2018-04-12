using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Opdracht : IComparable
    {
        public int OpdrachtId { get; set; }
        public int VolgNr { get; set; }
        public bool IsOpgelost { get; set; } // Groepsantwoord gevonden?
        public bool IsToegankelijk { get; set; } // Toegangscode gevonden?
        public bool IsGestart { get; set; } // Start gedrukt?
        public bool IsLaatsteOefening { get; set; } 
        public Actie Actie { get; set; } // UIT BOX
        public Oefening Oefening { get; set; } // UIT BOX
        public Toegangscode Toegangscode { get; set; } // UIT BOX
        public Groepsbewerking Groepsbewerking { get; set; } // MOET OOK UIT BOX 
        public int FoutePogingen { get; set; }
        public DateTime? StartTijd { get; set; }

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

        public void VerwerkAntwoord(string inputantwoord)
        {
            double? parsedinput = double.TryParse(inputantwoord.Replace('.', ','), out double outValue) ? (double?)outValue : null;
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

            if (!parsedinput.HasValue || parsedinput != correctAntwoord)
            {
                FoutePogingen++;
                if (FoutePogingen == 3)
                    throw new DrieFoutePogingenException("Je hebt 3 foute pogingen.");
                throw new FoutAntwoordException("Fout antwoord gegeven.");
            }
            else
                IsOpgelost = true;
        }

        public void VerwerkToegangscode(string inputcode)
        {
            Toegangscode.VerwerkToegangscode(inputcode);
            IsToegankelijk = true;
        }

        public void StartOpdracht()
        {
            if (StartTijd == null)
                StartTijd = DateTime.Now;
            IsGestart = true;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is Opdracht otherOpdracht)
                return VolgNr.CompareTo(otherOpdracht.VolgNr);
            else
                throw new ArgumentException("Object is not a Opdracht");
        }
    }
}