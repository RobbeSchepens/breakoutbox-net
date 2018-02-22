using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Leerling
    {
        #region Properties
        public int LeerlingId { get; private set; }
        public String Naam { get; set; }
        public String Voornaam { get; set; }
        //public Klas Klas { get; set; }
        public DateTime? GebDatum { get; set; }
        #endregion
        
        #region Constructors
        public Leerling()
        {
        }

        public Leerling(String naam, String voornaam, DateTime? gebDatum)
        {
            Naam = naam;
            Voornaam = voornaam;
            GebDatum = gebDatum;
        }
        #endregion
    }
}
