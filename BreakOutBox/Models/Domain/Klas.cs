

using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Klas
    {

        public int KlasId { get; set; }
        public ICollection<Leerling> LeerlingenInKlas { get; set; } // de leerlingen die in een klas zitten
        public ICollection<Leerkracht> LeerkrachtenInKlas { get; set; }


        public Klas(ICollection<Leerling>  leerlingenInKlas, ICollection<Leerkracht> leerkrachtenInKlas)
        {
            this.LeerlingenInKlas = leerlingenInKlas;
            this.LeerkrachtenInKlas = leerkrachtenInKlas;

        }
    }
}