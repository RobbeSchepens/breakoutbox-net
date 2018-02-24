using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Actie
    {
        public int ActieId { get; set; }
        public string Omschrijving { get; set; }

        public Actie(string omschrijving)
        {
            this.Omschrijving = omschrijving;
        }
    }
}
