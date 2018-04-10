namespace BreakOutBox.Models.Domain
{
    public enum EnumBewerking { OPTELLING, AFTREKKING, VERMENIGVULDIGING, DELING }

    public class Groepsbewerking
    {
        public EnumBewerking Bewerking { get; private set; }
        public double Getal { get; private set; }
        public Opdracht Opdracht { get; set; } // Voor one to one EF relatie

        public Groepsbewerking()
        {
        }

        public Groepsbewerking(EnumBewerking bewerking, double getal)
        {
            Bewerking = bewerking;
            Getal = getal;
        }
    }
}