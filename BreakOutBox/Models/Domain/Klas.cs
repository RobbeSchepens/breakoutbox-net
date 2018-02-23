using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Klas
    {
        public int KlasId { get; set; }
        public ICollection<Leerling> Leerlingen { get; set; }
        public ICollection<Leerkracht> Leerkrachten { get; set; }

        public Klas(ICollection<Leerling>  leerlingen, ICollection<Leerkracht> leerkrachten)
        {
            this.Leerlingen = leerlingen;
            this.Leerkrachten = leerkrachten;
        }
    }
}