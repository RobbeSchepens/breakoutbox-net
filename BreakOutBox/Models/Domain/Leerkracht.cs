using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Leerkracht
    {

        public int LeerkrachtId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public Klas klas { get; set; }


        public Leerkracht(string voornaam, string achternaam, Klas klas)
        {
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
            this.klas = klas;
        }

    }
}
