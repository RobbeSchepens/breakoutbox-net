namespace BreakOutBox.Models.Domain
{
    public class Leerling
    {
        public int LeerlingId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }

        public Leerling(string voornaam, string achternaam)
        {
            this.Voornaam = voornaam;
            this.Achternaam = achternaam;
        }
    }
}