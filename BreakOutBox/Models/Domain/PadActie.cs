namespace BreakOutBox.Models.Domain
{
    public class PadActie
    {
        public int PadId { get; set; }
        public Pad Pad { get; set; }

        public int ActieId { get; set; }
        public Actie Actie { get; set; }

        public PadActie()
        {
        }

        public PadActie(Pad pad, Actie actie) : this()
        {
            Pad = pad;
            PadId = Pad.PadId;

            Actie = actie;
            ActieId = Actie.ActieId;
        }
    }
}