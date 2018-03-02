using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Antwoord
    {
        public double Waarde { get; set; }

        public Antwoord(double waarde)
        {
            Waarde = waarde;
        }
    }
}
