using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Opgave
    {
        public int OpgaveId { get; set; }
        public string Vraag { get; set; }

        public Opgave(string vraag)
        {
            this.Vraag = vraag;
        }
    }
}
