using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Toegangscode
    {
        public double Waarde { get; set; }

        public Toegangscode(double waarde)
        {
            Waarde = waarde;
        }
    }
}
