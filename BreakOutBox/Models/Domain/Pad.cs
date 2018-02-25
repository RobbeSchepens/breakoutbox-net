using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Pad
    {
        public int PadId { get; set; }
        //public ICollection<Opdracht> Opdrachten { get; set; }
        //public ICollection<Actie> Acties { get; set; }
        public ICollection<PadOpdracht> PadOpdrachten { get; private set; }
        public IEnumerable<Opdracht> Opdrachten => PadOpdrachten.Select(k => k.Opdracht);
        public ICollection<PadActie> PadActies { get; private set; }
        public IEnumerable<Actie> Acties => PadActies.Select(k => k.Actie);

        public Pad()
        {
            PadOpdrachten = new HashSet<PadOpdracht>();
            PadActies = new HashSet<PadActie>();
        }

        //public Pad(ICollection<Opdracht> opdrachten, ICollection<Actie> acties)
        //{
        //    this.Opdrachten = opdrachten;
        //    this.Acties = acties;
        //}

        public void AddOpdracht(Opdracht k)
        {
            PadOpdrachten.Add(new PadOpdracht(this, k));
        }

        public void AddActie(Actie k)
        {
            PadActies.Add(new PadActie(this, k));
        }
    }
}
