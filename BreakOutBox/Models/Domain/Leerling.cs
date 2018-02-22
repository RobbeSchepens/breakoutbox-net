namespace BreakOutBox.Models.Domain
{
    public class Leerling
    {
        public int LeerlingId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public Klas Klas { get; set; }


        public Leerling(string voornaam, string achternaam, Klas klas)
        {
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
            this.Klas = klas;
        }



    }
}