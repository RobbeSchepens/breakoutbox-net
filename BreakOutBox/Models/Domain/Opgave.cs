using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Opgave
    {

        public int OpgaveId { get; set; }
        public ICollection<String> RekenSommen { get; set; }    
        public string UitlegOpdracht { get; set; }



        public Opgave(string uitlegOpdracht, ICollection<String>  rekenSommen)
        {
            this.UitlegOpdracht = uitlegOpdracht;
            this.RekenSommen = rekenSommen;

        }
    }
}
