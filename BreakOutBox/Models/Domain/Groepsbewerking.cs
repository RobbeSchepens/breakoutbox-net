namespace BreakOutBox.Models.Domain
{
    public enum EnumBewerking { OPTELLING, AFTREKKING, VERMENIGVULDIGING, DELING }

    public class Groepsbewerking
    {
        public int GroepsbewerkingId { get; set; }
        public EnumBewerking Bewerking { get; private set; }
        public double Getal { get; private set; }
        public int OpdrachtIdFK { get; set; } // Voor one to one EF relatie
        public Opdracht Opdracht { get; set; } // Voor one to one EF relatie

        public Groepsbewerking()
        {
        }

        public Groepsbewerking(EnumBewerking bewerking, double getal)
        {
            Bewerking = bewerking;
            Getal = getal;
        }

        public override string ToString()
        {
            switch (Bewerking)
            {
                case EnumBewerking.OPTELLING:
                    return "Tel er " + Getal + " bij op.";
                case EnumBewerking.AFTREKKING:
                    return "Trek er " + Getal + " van af.";
                case EnumBewerking.VERMENIGVULDIGING:
                    return "Vermenigvuldig met " + Getal + ".";
                case EnumBewerking.DELING:
                    return "Deel door " + Getal + ".";
            }
            return null;
        }
    }
}