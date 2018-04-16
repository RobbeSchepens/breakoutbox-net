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
        public int MaxTijdInMinuten { get; set; } = 30; // Gedefinieerde max tijd per opdracht
        public bool IsOpgelost { get; set; } // Groepsantwoord gevonden?
        public bool IsToegankelijk { get; set; } // Toegangscode gevonden?
        public bool IsGestart { get; set; } // Start gedrukt?
        public bool IsLaatsteOefening { get; set; } 
        public Actie Actie { get; set; } // UIT BOX
        public Oefening Oefening { get; set; } // UIT BOX
        public Toegangscode Toegangscode { get; set; } // UIT BOX
        public Groepsbewerking Groepsbewerking { get; set; } // MOET OOK UIT BOX 
        public DateTime? StartTijd { get; private set; }
        public int FoutePogingen { get; set; }
        public int GespendeerdeSeconden { get; set; } // Tijd die al gespendeerd is aan de opdracht
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
        /// <exception cref="DrieFoutePogingenException">Wordt gegooid wanneer er een veelvoud van 3 pogingen geteld wordt.</exception>
        /// <exception cref="FoutAntwoordException">Wordt gegooid wanneer het opgegeven antwoord en berekende groepsantwoord niet gelijk zijn.</exception>
        /// <exception cref="TijdVerstrekenException">Wordt gegooid wanneer het verschil tussen DateTime.Now 
        /// en de DateTime in prop StartTijd hoger is dan de prop MaxTijdInMinuten.</exception>
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

            // bereken verschil in minuten tussen gespendeerdetijd + starttijd en nu
            // @TODO Wat als er pauze genomen wordt? 
            if (StartTijd != null && OpdrachtBepaler is EnumOpdrachtBepaler.TIJD && (GespendeerdeSeconden /60 + (DateTime.Now - StartTijd).Value.TotalMinutes) >= MaxTijdInMinuten)
            {
                StopOpdracht();
                throw new TijdVerstrekenException($"Er zijn {MaxTijdInMinuten} minuten verstreken.");
            }

            if (!parsedinput.HasValue || parsedinput != correctAntwoord)
            {
                FoutePogingen++;

                if (OpdrachtBepaler is EnumOpdrachtBepaler.POGINGEN && FoutePogingen % Pogingen == 0)
                    throw new DrieFoutePogingenException($"Je hebt {Pogingen} foute pogingen.");
                throw new FoutAntwoordException("Fout antwoord gegeven.");
            }
            else
            {
                StopOpdracht();
                IsOpgelost = true;
            }
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

        public void StopOpdracht()
        {
            if (StartTijd != null)
            {
                GespendeerdeSeconden += (int)(DateTime.Now - StartTijd).Value.TotalSeconds;
                StartTijd = null;
            }
        }

        public void GeefNieuweTijd(int opgegevenminuten)
        {
            StartTijd = DateTime.Now;
            MaxTijdInMinuten = opgegevenminuten;
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