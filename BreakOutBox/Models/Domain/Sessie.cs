using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Sessie
    {
        public int SessieId { get; set; }
        public string UniekeCode { get; set; }
        public Klas Klas { get; set; }
        public ICollection<Groep> Groepen { get; set; }
        public string UniekeNaam { get; set; }
        public string Omschrijving { get; set; }

        public Sessie()
        {

        }
        public Sessie(string uniekeCode, Klas klas, ICollection<Groep> groepen, string uniekeNaam, string omschrijving)
        {
            this.UniekeCode = uniekeCode;
            this.Klas = Klas;
            this.Groepen = groepen;
            this.UniekeNaam = uniekeNaam;
            this.Omschrijving = omschrijving;
        }


    }
}
