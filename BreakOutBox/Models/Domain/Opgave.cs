using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Opgave
    {
        public int OpgaveId { get; set; }
        public ICollection<OpgaveVraag> Vragen { get; set; }
        public string Uitleg { get; set; }

        public Opgave(string uitleg, ICollection<OpgaveVraag> vragen)
        {
            this.Uitleg = uitleg;
            this.Vragen = vragen;
        }
    }
}
