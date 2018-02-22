using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Klas
    {
        #region Properties
        public int KlasId { get; private set; }
        public ICollection<Leerkracht> LeerkrachtenVanKlas { get; set; }
        public ICollection<Leerling> Leerlingen { get; set; }
        #endregion

        #region Constructors
        public Klas()
        {
        }

        public Klas(ICollection<Leerkracht> leerkrachtenVanKlas, ICollection<Leerling> leerlingen)
        {
            LeerkrachtenVanKlas = leerkrachtenVanKlas;
            Leerlingen = leerlingen;
        }
        #endregion
    }
}
