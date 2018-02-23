using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Actie
    {
        public int ActieId { get; set; }
        public string OmschrijvingActie { get; set; }

        public Actie(string omschrijvingActie)
        {
            this.OmschrijvingActie = omschrijvingActie;
        }
    }
}
