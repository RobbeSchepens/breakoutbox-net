using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Sessie
    {
        #region Properties
        public int SessieId { get; private set; }
        public string UniekeCode { get; set; }
        public string Naam { get; set; }
        //public string Klas { get; set; }
        public string Omschrijving { get; set; }
        public ICollection<Opdracht> OpdrachtenPool { get; set; }
        public ICollection<Groep> Groepen { get; set; }
        public Leerkracht Leerkracht { get; set; }
        #endregion

        #region Constructors
        public Sessie()
        {
            OpdrachtenPool = new HashSet<Opdracht>();
            Groepen = new HashSet<Groep>();
        }

        public Sessie(string uniekeCode, string naam, string omschrijving, ICollection<Opdracht> opdrachtenPool, ICollection<Groep> groepen, Leerkracht leerkracht)
        {
            UniekeCode = uniekeCode;
            Naam = naam;
            Omschrijving = omschrijving;
            OpdrachtenPool = opdrachtenPool;
            Groepen = groepen;
            Leerkracht = leerkracht;
        }
        #endregion
    }
}
