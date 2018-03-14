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
        public Klas()
        {
            KlasLeerkrachten = new HashSet<KlasLeerkracht>();
        }

        public Klas(ICollection<Leerling> leerlingen)
        {
            Leerlingen = leerlingen;
            KlasLeerkrachten = new HashSet<KlasLeerkracht>();
        }
        #endregion

        #region Methods

    

        public void VoegLeerkrachtToe(Leerkracht k)
        {
            KlasLeerkrachten.Add(new KlasLeerkracht(this, k));
        }
        #endregion Methods
    }
}