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

        public void VoegOpdrachtToe(Opdracht opdracht)
        {
            PadOpdrachten.Add(new PadOpdracht(this, opdracht));
        }

        public void VoegActieToe(Actie actie)
        {
            PadActies.Add(new PadActie(this, actie));
        }

        public void VerwijderOpdracht(Opdracht opdracht)
        {
            if (!PadOpdrachten.Contains(new PadOpdracht(this, opdracht)))
                throw new ArgumentException($"Opdracht met volgnr {opdracht.VolgNr} is geen bestaande opdracht.");
            PadOpdrachten.Remove(new PadOpdracht(this, opdracht));
        }

        public void VerwijderActie(Actie actie)
        {
            if (!PadActies.Contains(new PadActie(this, actie)))
                throw new ArgumentException($"Actie met id {actie.ActieId} is geen bestaande actie.");
            PadActies.Remove(new PadActie(this, actie));
        }
    }
}
