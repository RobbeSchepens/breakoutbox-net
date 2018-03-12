namespace BreakOutBox.Models.Domain
{
    public class Vak
    {
        public int VakId { get; set; }
        public string Naam { get; set; }

        public Vak()
        {
        }

        public Vak(string naam)
        {
            Naam = naam;
        }
    }
}