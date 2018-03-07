using System;
using System.Collections.Generic;
using System.Linq;

namespace BreakOutBox.Models.Domain
{
    public class Klas
    {
        #region Properties
        public int KlasId { get; set; }
        public ICollection<Leerling> Leerlingen { get; set; }
        public ICollection<KlasLeerkracht> KlasLeerkrachten { get;  set; } // hier stond private set
        public ICollection<Leerkracht> Leerkrachten { get;  set; } //=> KlasLeerkrachten.Select(k => k.Leerkracht); Veranderd omdat ik anders geen leerkracht kon toevoegen
        public int NrOfLeerlingen => Leerlingen.Count;
        public int NrOfLeerkrachten => KlasLeerkrachten.Count;
        #endregion

        #region Constructors

        public Klas()
        {

        }
        public Klas(ICollection<Leerling> leerlingen, ICollection<KlasLeerkracht> klasLeerkrachten)
        {
            KlasLeerkrachten = klasLeerkrachten;
            Leerlingen = leerlingen;
        }
        #endregion

        #region Methods
        #endregion Methods
    }
}