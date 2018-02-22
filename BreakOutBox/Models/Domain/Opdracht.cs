using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Opdracht
    {
        #region Properties
        public int OpdrachtId { get; private set; }
        public int OpdrachtNummer { get; set; }
        public string Categorie { get; set; }
        public string Omschrijving { get; set; }
        public string Antwoord { get; set; }
        #endregion
        
        #region Constructors
        public Opdracht()
        {
        }

        public Opdracht(int opdrachtNummer, string categorie, string omschrijving, string antwoord)
        {
            OpdrachtNummer = opdrachtNummer;
            Categorie = categorie;
            Omschrijving = omschrijving;
            Antwoord = antwoord;
        }
        #endregion
    }
}
