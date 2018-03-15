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
        public Leerkracht Leerkracht { get; set; }
        public int NrOfLeerlingen => Leerlingen.Count;
        #endregion

        #region Constructors
        public Klas()
        {
            Leerlingen = new HashSet<Leerling>();
        }

        public Klas(ICollection<Leerling> leerlingen, Leerkracht leerkracht)
        {
            Leerlingen = leerlingen;
            Leerkracht = leerkracht;
        }
        #endregion
    }
}