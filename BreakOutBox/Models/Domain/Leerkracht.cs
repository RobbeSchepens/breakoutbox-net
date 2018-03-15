using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Leerkracht
    {
        public int LeerkrachtId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public ICollection<Sessie> Sessies { get; set; }
        public ICollection<Klas> Klassen { get; set; }

        public Leerkracht()
        {
            Sessies = new HashSet<Sessie>();
            Klassen = new HashSet<Klas>();
        }

        public Leerkracht(string voornaam, string achternaam)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Sessies = new HashSet<Sessie>();
            Klassen = new HashSet<Klas>();
        }

        public void VoegSessieToe(Sessie sessie)
        {
            Sessies.Add(sessie);
        }

        public void VoegKlasToe(Klas klas)
        {
            Klassen.Add(klas);
        }
    }
}
