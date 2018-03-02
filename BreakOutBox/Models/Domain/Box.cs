using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Box
    {
        public ICollection<Toegangscode> Toegangscodes { get; set; }
        public ICollection<Actie> Acties { get; set; }
        public ICollection<Oefening> Oefeningen { get; set; }

        public Box(ICollection<Toegangscode> toegangscodes, ICollection<Actie> acties, ICollection<Oefening> oefeningen)
        {
            Toegangscodes = toegangscodes;
            Acties = acties;
            Oefeningen = oefeningen;
        }
    }
}
