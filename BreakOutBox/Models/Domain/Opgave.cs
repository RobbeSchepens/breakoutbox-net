using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Opgave
    {
        public int OpgaveId { get; set; }
        public ICollection<String> Vragen { get; set; }
        public string UitlegOefening { get; set; }

        public Opgave(string uitlegOefening, ICollection<String> vragen)
        {
            this.UitlegOefening = uitlegOefening;
            this.Vragen = vragen;
        }
    }
}
