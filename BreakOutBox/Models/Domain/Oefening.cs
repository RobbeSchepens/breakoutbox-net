using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Oefening
    {
        public int OefeningId { get; set; }
        public string OefeningNaam { get; set; }
        public Opgave Opgave { get; set; }
        public string Antwoord { get; set; }
        public Feedback Feedback { get; set; }
        public ICollection<GroepsBewerking> GroepsBewerking { get; set; }


        public Oefening(string oefeningNaam, Opgave opgave, string antwoord, Feedback feedback, ICollection<GroepsBewerking> groepsBewerking)
        {
            this.OefeningNaam = oefeningNaam;
            this.Opgave = opgave;
            this.Feedback = feedback;
            this.GroepsBewerking = groepsBewerking;

        }
    }
}
