using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Pad
    {
        public int PadId { get; set; }
        public ICollection<Opdracht> Opdrachten { get; set; }
        public int GroepId { get; set; } // Voor one to one EF relatie.
        public Groep Groep { get; set; } // Voor one to one EF relatie.
        
        public Pad()
        {
        }

        public Pad(ICollection<Opdracht> opdrachten)
        {
            Opdrachten = opdrachten;
        }

        public Opdracht getNextOpdracht(Opdracht opdracht)
        {
            try
            {
            }       
            catch
            {
            }       
            
            int indexCurrent = Opdrachten.ToList().IndexOf(opdracht);
            return Opdrachten.ToList()[indexCurrent+1];
        }
    }
}
