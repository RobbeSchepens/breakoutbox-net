using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public enum EnumOpdrachtBepaler { POGINGEN, TIJD }

    public class Opdracht : IComparable
    {
        #region Properties
        public int OpdrachtId { get; set; }
        public int VolgNr { get; set; }
        public int Pogingen { get; set; } = 3;
        public int TijdInMinuten { get; set; } = 30;
        public bool IsOpgelost { get; set; } // Groepsantwoord gevonden?
        public bool IsToegankelijk { get; set; } // Toegangscode gevonden?
        public bool IsGestart { get; set; } // Start gedrukt?
        public bool IsLaatsteOefening { get; set; } 
        public Actie Actie { get; set; } // UIT BOX
        public Oefening Oefening { get; set; } // UIT BOX
        public Toegangscode Toegangscode { get; set; } // UIT BOX
        public Groepsbewerking Groepsbewerking { get; set; } // MOET OOK UIT BOX 
        public DateTime? StartTijd { get; set; }
        public int FoutePogingen { get; set; }
        public EnumOpdrachtBepaler OpdrachtBepaler { get; private set; }
        #endregion

        #region Constructors
        public Opdracht()
        {
        }

        public Opdracht(int volgNr, Actie actie, Oefening oefening, Toegangscode toegangscode, Groepsbewerking groepsbewerking, EnumOpdrachtBepaler opdrachtBepaler)
        {
            VolgNr = volgNr;
            Actie = actie;
            Oefening = oefening;
            Toegangscode = toegangscode;
            Groepsbewerking = groepsbewerking;
            OpdrachtBepaler = opdrachtBepaler;
        }
        #endregion

        #region Methods
        public void VerwerkAntwoord(string inputantwoord)
        {
            // Probeer te parsen. Als er geen double gemaakt kan worden, is het resultaat null
            // @TODO Internationalisering/taalinstellingen doubles met . of ,
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
                if (OpdrachtBepaler is EnumOpdrachtBepaler.POGINGEN)
                {
                    FoutePogingen++;
                    if (FoutePogingen % Pogingen == 0)
                        throw new DrieFoutePogingenException($"Je hebt {Pogingen} foute pogingen.");
                    throw new FoutAntwoordException("Fout antwoord gegeven.");
                }
                else if (OpdrachtBepaler is EnumOpdrachtBepaler.TIJD)
                {
                    // bereken verschil in minuten tussen starttijd en nu
                    // @TODO Berekent verschil van starttijd, maar wat als er pauze genomen wordt? 
                    if (StartTijd != null && (DateTime.Now - StartTijd).Value.Minutes >= TijdInMinuten)
                        throw new TijdVerstrekenException($"Er zijn {TijdInMinuten} minuten verstreken.");
                    throw new FoutAntwoordException("Fout antwoord gegeven.");
                }
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
        #endregion
    }
}