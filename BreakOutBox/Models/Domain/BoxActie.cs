namespace BreakOutBox.Models.Domain
{
    public class BoxActie
    {
        public int BoxId { get; set; }
        public Box Box { get; set; }

        public int ActieId { get; set; }
        public Actie Actie { get; set; }

        public BoxActie()
        {
        }

        public BoxActie(Box box, Actie actie) : this()
        {
            Box = box;
            BoxId = Box.BoxId;

            Actie = actie;
            ActieId = Actie.ActieId;
        }
    }
}