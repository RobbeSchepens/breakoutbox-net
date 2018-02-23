using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Pad
    {
        public ICollection<Opdracht> Opdrachten { get; set; }
        public ICollection<Actie> Acties { get; set; }

        public Pad(ICollection<Opdracht> opdrachten, ICollection<Actie> acties)
        {
            this.Opdrachten = opdrachten;
            this.Acties = acties;
        }
    }
}
