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
        public ICollection<KlasLeerkracht> KlasLeerkrachten { get; private set; }
        public IEnumerable<Leerkracht> Leerkrachten => KlasLeerkrachten.Select(k => k.Leerkracht);
        public int NrOfLeerlingen => Leerlingen.Count;
        public int NrOfLeerkrachten => KlasLeerkrachten.Count;
        #endregion

        #region Constructors
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