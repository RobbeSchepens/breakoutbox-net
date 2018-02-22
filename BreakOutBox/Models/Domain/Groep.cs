
using System.Collections.Generic;


namespace BreakOutBox.Models.Domain
{
    public class Groep
    {
        #region Properties

        #endregion
        public int GroepId { get; set; }
        public string Groepnaam { get; set; }
        public ICollection<Leerling> LeerlingenInGroep { get; set; }
        private ICollection<Pad> Paden { get; set; }




        public Groep(string groepnaam, ICollection<Leerling> leerlingenInGroep, ICollection<Pad> paden)
        {
            this.Groepnaam = groepnaam;
            this.LeerlingenInGroep = leerlingenInGroep;
            this.Paden = paden;
        }
    }
}