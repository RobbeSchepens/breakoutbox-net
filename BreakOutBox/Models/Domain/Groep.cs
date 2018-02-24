using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Groep
    {
        public int GroepId { get; set; }
        public string Naam { get; set; }
        public ICollection<Leerling> Leden { get; set; }
        public ICollection<Pad> Paden { get; set; }

        public Groep(string naam, ICollection<Leerling> leden, ICollection<Pad> paden)
        {
            this.Naam = naam;
            this.Leden = leden;
            this.Paden = paden;
        }
    }
}