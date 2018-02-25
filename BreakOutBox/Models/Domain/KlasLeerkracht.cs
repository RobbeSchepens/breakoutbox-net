using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class KlasLeerkracht
    {
        public int KlasId { get; set; }
        public Klas Klas { get; set; }

        public int LeerkrachtId { get; set; }
        public Leerkracht Leerkracht { get; set; }

        protected KlasLeerkracht()
        {
        }

        public KlasLeerkracht(Klas klas, Leerkracht leerkracht) : this()
        {
            Klas = klas;
            KlasId = Klas.KlasId;

            Leerkracht = leerkracht;
            LeerkrachtId = Leerkracht.LeerkrachtId;
        }
    }
}
