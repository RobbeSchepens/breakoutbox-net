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
        public string Opgave { get; set; } // Een path bvb: "oef/oefening1.pdf"
        public double Antwoord { get; set; } // Het antwoord VOORALEER de groepsbewerking toe te passen
        //public Antwoord Antwoord { get; set; }
        //public Feedback Feedback { get; set; }
        public string Groepsbewerking { get; set; } // De bewerking. Het resultaat van antwoord + groepsbewerking wordt 'on the spot' uitgerekend. 
        public Opdracht Opdracht { get; set; }

        public Oefening(string oefeningNaam, string opgave, string groepsbewerking)
        {
            Naam = oefeningNaam;
            Opgave = opgave;
            //Feedback = feedback;
            //Antwoord = antwoord;
            Groepsbewerking = groepsbewerking;
        }
    }
}
