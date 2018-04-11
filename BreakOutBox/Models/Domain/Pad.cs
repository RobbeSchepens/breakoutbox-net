using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Pad
    {
        #region Fields
        private IList<Opdracht> _opdrachten;
        #endregion

        #region Properties
        public int PadId { get; set; }
        public IList<Opdracht> Opdrachten
        {
            get => _opdrachten;
            set => _opdrachten = value.OrderBy(e => e.VolgNr).ToList();
        }
        public int GroepIdFK { get; set; } // Voor one to one EF relatie.
        public Groep Groep { get; set; } // Voor one to one EF relatie.
        #endregion

        #region Constructors
        public Pad()
        {
        }

        public Pad(IList<Opdracht> opdrachten)
        {
            Opdrachten = opdrachten;
            Opdrachten.ElementAt(0).IsToegankelijk = true;
            Opdrachten.ElementAt(0).IsGestart = true;
        }
        #endregion

        #region Methods
        public Opdracht GetCurrentOpdracht()
        {
            if (Opdrachten.OrderBy(e => e.VolgNr).LastOrDefault().IsOpgelost)
                throw new AlleOpdrachtenVoltooidException("Alle opdrachten zijn voltooid.");

            return Opdrachten.OrderBy(e => e.VolgNr).Where(e => e.IsToegankelijk && e.IsGestart).LastOrDefault();
        }

        public Opdracht GetNextOpdracht()
        {
            try
            {
                int indexCurrent = Opdrachten.IndexOf(GetCurrentOpdracht());
                return Opdrachten[indexCurrent + 1];
            }
            catch (ArgumentOutOfRangeException) // in catch als laatste oefening
            {
                return null;
            }
        }
        
        public List<int> GetProgressie()
        {
            return new List<int>
            {
                GetCurrentOpdracht().VolgNr,
                Opdrachten.Count
            };
        }

        public void VerwerkToegangscode(double inputcode)
        {
            GetNextOpdracht().VerwerkToegangscode(inputcode);
        }

        public void StartVolgendeOpdracht()
        {
            // Eerste opdracht, anders daaropvolgende opdrachten
            if (Opdrachten.OrderBy(e => e.VolgNr).FirstOrDefault() == GetCurrentOpdracht() && !GetNextOpdracht().IsToegankelijk)
                GetCurrentOpdracht().StartOpdracht();
            else if (GetCurrentOpdracht().IsOpgelost && GetNextOpdracht().IsToegankelijk)
                GetNextOpdracht().StartOpdracht();
        }
        #endregion
    }
}
