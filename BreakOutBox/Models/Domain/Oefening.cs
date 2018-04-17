using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Oefening
    {
        public int OefeningId { get; set; }
        public string Naam { get; set; }
        public string Opgave { get; set; } // Een path bvb: "oef/oefening1.pdf"
        public double Antwoord { get; set; } // Het antwoord VOORALEER de groepsbewerking toe te passen
        public string Feedback { get; set; }
        public Vak Vak { get; set; }

        public Oefening()
        {
        }

        public Oefening(string naam, string opgave, double antwoord, Vak vak)
        {
            Naam = naam;
            Opgave = opgave;
            Antwoord = antwoord;
            Vak = vak;
        }
    }
}
