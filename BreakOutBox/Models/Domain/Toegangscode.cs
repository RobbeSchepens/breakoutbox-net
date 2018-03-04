using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Toegangscode
    {
        public int ToegangscodeId { get; set; }
        public double Code { get; set; }

        public Toegangscode(double code)
        {
            Code = code;
        }
    }
}
