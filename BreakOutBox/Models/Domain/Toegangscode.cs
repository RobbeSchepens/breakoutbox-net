using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Toegangscode
    {
        public int ToegangscodeId { get; set; }
        public double Code { get; private set; }
        public Opdracht Opdracht { get; set; } // Voor one to one EF relatie
        
        public Toegangscode()
        {
        }

        public Toegangscode(double code)
        {
            Code = code;
        }
    }
}
