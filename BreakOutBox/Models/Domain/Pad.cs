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

                int indexCurrent = Opdrachten.ToList().IndexOf(opdracht);
                return Opdrachten.ToList()[indexCurrent + 1];
            }       
            catch
            {
                var actie = new Actie();
                var oef = new Oefening();
                var toegCode = new Toegangscode();

                new Opdracht();
                int volgNr, Actie actie, Oefening oefening, Toegangscode toegangscode

            }       
            
          
        }

        public List<int> getProgressie(Opdracht huidigeOpdracht)
        {
            List<int> progressieList = new List<int>(); // elem 1 is het vraagnummer waaraan de groep zit, elem 2 het totaal aantal vragen
            progressieList.Add(Opdrachten.Count);
            progressieList.Add(Opdrachten.ToList().IndexOf(huidigeOpdracht));
            return progressieList;
        }

    }
}
