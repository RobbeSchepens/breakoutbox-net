using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Leerkracht
    {
        #region Properties
        public int LeerkrachtId { get; private set; }
        public string Naam { get; set; }
        public String Voornaam { get; set; }
        #endregion

        #region Constructors
        public Leerkracht(String naam, String voornaam)
        {
            Naam = naam;
            Voornaam = voornaam;
        }
        #endregion
    }
}
