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

        public void VerwerkToegangscode(string inputcode)
        {
            double? parsedinput = double.TryParse(inputcode.Replace('.', ','), out double outValue) ? (double?)outValue : null;

            if (!parsedinput.HasValue || parsedinput != Code)
                throw new FouteToegangscodeException("Je hebt een foute toegangscode opgegeven.");
        }
    }
}
