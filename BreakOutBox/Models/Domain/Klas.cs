using System.Collections.Generic;
using System.Linq;

namespace BreakOutBox.Models.Domain
{
    public class Klas
    {
        public int KlasId { get; set; }
        public ICollection<Leerling> Leerlingen { get; set; }
        public ICollection<KlasLeerkracht> KlasLeerkrachten { get; private set; }
        public IEnumerable<Leerkracht> Leerkrachten => KlasLeerkrachten.Select(k => k.Leerkracht);

        public Klas()
        {
            KlasLeerkrachten = new HashSet<KlasLeerkracht>();
            Leerlingen = new HashSet<Leerling>();
        }

        public void VoegLeerkrachtToe(Leerkracht leerkracht)
        {
            KlasLeerkrachten.Add(new KlasLeerkracht(this, leerkracht));
        }

        public void VoegLeerlingToe(Leerling leerling)
        {
            Leerlingen.Add(leerling);
        }
    }
}