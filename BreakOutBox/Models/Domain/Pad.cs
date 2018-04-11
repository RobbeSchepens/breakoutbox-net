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
        public int GroepIdFK { get; set; } // Voor one to one EF relatie.
        public Groep Groep { get; set; } // Voor one to one EF relatie.
        
        public Pad()
        {
        }

        public Pad(ICollection<Opdracht> opdrachten)
        {
            Opdrachten = opdrachten;
            Opdrachten.ElementAt(0).IsToegankelijk = true;
        }

        public Opdracht GetNextOpdracht()
        {
            try
            {
                int indexCurrent = Opdrachten.ToList().IndexOf(GetCurrentOpdracht());
                return Opdrachten.ToList()[indexCurrent + 1];
            }
            catch (ArgumentOutOfRangeException) // in catch als laatste oefeningn
            {
                return null;

                //var actie = new Actie("");
                //var oef = new Oefening("","",0,new Vak(""));
                //var toegCode = new Toegangscode(0);
                
                //return new Opdracht(20000,actie,oef,toegCode,new Groepsbewerking(0, 10));
                //int volgNr, Actie actie, Oefening oefening, Toegangscode toegangscode
            }
        }

        public Opdracht GetCurrentOpdracht()
        {
            try
            {
                return Opdrachten.Where(t => !t.IsOpgelost && t.IsToegankelijk).FirstOrDefault();
            }
            catch (NullReferenceException)
            {
                throw new AlleOpdrachtenVoltooidException("Alle opdrachten zijn voltooid.");
            }
        }

        //public bool CheckToegangscode(string toegangscode)
        //{
        //    if (toegangscode == GetNextOpdracht().Toegangscode.Code.ToString())
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        
        public List<int> GetProgressie()
        {
            List<int> progressieList = new List<int>();
            progressieList.Add(Opdrachten.ToList().IndexOf(GetCurrentOpdracht()) + 1);
            progressieList.Add(Opdrachten.Count);
            return progressieList;
        }

        public void VerwerkToegangscode(double inputcode)
        {
            GetNextOpdracht().VerwerkToegangscode(inputcode);
        }
    }
}
