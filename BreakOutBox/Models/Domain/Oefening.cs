using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Oefening
    {
        public int OefeningId { get; set; }
        public string Naam { get; set; }
        public Opgave Opgave { get; set; }
        public Antwoord Antwoord { get; set; }
        public Feedback Feedback { get; set; }
        public Groepsbewerking Groepsbewerking { get; set; }

        public Oefening(string oefeningNaam, Opgave opgave, Antwoord antwoord, Feedback feedback, Groepsbewerking groepsbewerking)
        {
            this.Naam = oefeningNaam;
            this.Opgave = opgave;
            this.Feedback = feedback;
            this.Antwoord = antwoord;
            this.Groepsbewerking = groepsbewerking;
        }
    }
}
