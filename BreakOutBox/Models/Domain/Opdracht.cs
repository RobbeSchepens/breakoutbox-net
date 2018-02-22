namespace BreakOutBox.Models.Domain
{
    public class Opdracht
    {
        public int OpdrachtId { get; set; }
        public int VolgNr { get; set; }
        public Oefening Oefening { get; set; }    
        public int ToegangscodeUitBox { get; set; }


        public Opdracht(int volgNr, Oefening oefening, int toegangscodeUitBox)
        {
            this.VolgNr = volgNr;
            this.Oefening = oefening;
            this.ToegangscodeUitBox = toegangscodeUitBox;
        }
    }
}