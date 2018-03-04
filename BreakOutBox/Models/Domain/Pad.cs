using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Pad
    {
        public int PadId { get; set; }
        public ICollection<PadOpdracht> PadOpdrachten { get; private set; }
        public IEnumerable<Opdracht> Opdrachten => PadOpdrachten.Select(k => k.Opdracht);
        public ICollection<PadActie> PadActies { get; private set; }
        public IEnumerable<Actie> Acties => PadActies.Select(k => k.Actie);
        public int NrOfOpdrachten => PadOpdrachten.Count;
        public int NrOfActies => PadActies.Count;

        public Pad()
        {
            PadOpdrachten = new HashSet<PadOpdracht>();
            PadActies = new HashSet<PadActie>();
        }
    }
}
