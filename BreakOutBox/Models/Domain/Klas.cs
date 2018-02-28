using System.Collections.Generic;
using System.Linq;

namespace BreakOutBox.Models.Domain
{
    public class Klas
    {
        public int KlasId { get; set; }
        public ICollection<Leerling> Leerlingen { get; set;§ }
        //public ICollection<Leerkracht> Leerkrachten { get; set; }
        public ICollection<KlasLeerkracht> KlasLeerkrachten { get; private set; }
        public IEnumerable<Leerkracht> Leerkrachten => KlasLeerkrachten.Select(k => k.Leerkracht);

        public Klas()
        {
            KlasLeerkrachten = new HashSet<KlasLeerkracht>();
        }

        public Klas(ICollection<Leerling>  leerlingen)
        {
            this.Leerlingen = leerlingen;
        }

        public void Add(Leerkracht lk)
        {
            KlasLeerkrachten.Add(new KlasLeerkracht(this, lk));
        }
    } 
}