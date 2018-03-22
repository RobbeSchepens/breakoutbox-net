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

        public Opdracht getNextOpdracht()
        {
            try
            {
                int indexCurrent = Opdrachten.ToList().IndexOf(getCurrentOpdracht());
                return Opdrachten.ToList()[indexCurrent + 1];
            }       
            catch // in catch als laatste oefeningn
            {
                var actie = new Actie("");
                var oef = new Oefening("","",0,new Vak(""));
                var toegCode = new Toegangscode(0);

                return new Opdracht(20000, actie,oef,toegCode);
                //int volgNr, Actie actie, Oefening oefening, Toegangscode toegangscode
            }                  
        }

        public Opdracht getCurrentOpdracht()
        {
            return Opdrachten.Where(t => !t.Opgelost).FirstOrDefault();

        }
        public bool CheckToegangscode(string toegangscode)
        {
            if (toegangscode == getNextOpdracht().Toegangscode.Code.ToString())
            {
                return true;
            }
            return false;
        }


        public List<int> getProgressie()
        {
            List<int> progressieList = new List<int>(); // elem 1 is het vraagnummer waaraan de groep zit, elem 2 het totaal aantal vragen
            progressieList.Add(Opdrachten.Count);
            progressieList.Add(Opdrachten.ToList().IndexOf(getCurrentOpdracht()));
            return progressieList;
        }

    }
}
