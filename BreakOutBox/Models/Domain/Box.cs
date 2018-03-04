using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Box
    {
        public int BoxId { get; set; }
        //public ICollection<Toegangscode> Toegangscodes { get; set; }
        //public ICollection<Actie> Acties { get; set; }
        //public ICollection<Oefening> Oefeningen { get; set; }
        public ICollection<BoxActie> BoxActies { get; private set; }
        public IEnumerable<Actie> Acties => BoxActies.Select(k => k.Actie);
        public ICollection<BoxOefening> BoxOefeningen { get; private set; }
        public IEnumerable<Oefening> Oefeningen => BoxOefeningen.Select(k => k.Oefening);
        public ICollection<BoxToegangscode> BoxToegangscodes { get; private set; }
        public IEnumerable<Toegangscode> Toegangscodes => BoxToegangscodes.Select(k => k.Toegangscode);

        public Box(ICollection<BoxToegangscode> boxtoegangscodes, ICollection<BoxActie> boxacties, ICollection<BoxOefening> boxoefeningen)
        {
            BoxActies = boxacties;
            BoxOefeningen = boxoefeningen;
            BoxToegangscodes = boxtoegangscodes;
        }
    }
}
