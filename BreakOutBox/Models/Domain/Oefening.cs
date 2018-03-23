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
        public string Groepsbewerking { get; set; } // De bewerking. Het resultaat van antwoord + groepsbewerking wordt 'on the spot' uitgerekend. 
        public string Feedback { get; set; }
        public Vak Vak { get; set; }



        public Oefening()
        {

        }
        public Oefening(string oefeningNaam, string opgave, double antwoord, Vak vak)
        {
            Naam = oefeningNaam;
            Opgave = opgave;
            Antwoord = antwoord;
            Vak = vak;
        }

        public string AntwoordMetGroepsbewerking()
        {
            string antw = Antwoord.ToString(); ;

           
            string resultString = Regex.Match(Groepsbewerking, @"\d+").Value;
            int getalInString = Int32.Parse(resultString);


            if (antw.Contains("+"))
                return (Antwoord + getalInString).ToString();
            if (antw.Contains("-"))
                return (Antwoord + getalInString).ToString();
            if (antw.Contains("*"))
                return (Antwoord + getalInString).ToString();
            if (antw.Contains("/"))
                return (Antwoord + getalInString).ToString();
          

            return "fout";

        }


    }
}
