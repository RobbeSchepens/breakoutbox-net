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
        public string Email { get; set; }

        public Leerkracht()
        {
            Sessies = new HashSet<Sessie>();
            Klassen = new HashSet<Klas>();
        }

        public Leerkracht(string voornaam, string achternaam, string email)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Sessies = new HashSet<Sessie>();
            Klassen = new HashSet<Klas>();
            Email = email;
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
