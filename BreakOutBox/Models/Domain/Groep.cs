using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Groep
    {
        #region Properties
        public int GroepId { get; private set; }
        public string GroepsNaam { get; set; }
        public ICollection<Leerling> GroepsLeden { get; set; }
        public ICollection<Opdracht> OpdrachtenPad { get; set; }
        #endregion

        #region Constructors
        public Groep()
        {
            GroepsLeden = new HashSet<Leerling>();
            OpdrachtenPad = new HashSet<Opdracht>();
        }

        public Groep(string groepsNaam, ICollection<Leerling> groepsLeden)
        {
            GroepId = 0;
            GroepsNaam = groepsNaam;
            GroepsLeden = groepsLeden;
        }
        #endregion
    }
}
