namespace BreakOutBox.Models.Domain
{
    public class BoxOefening
    {
        public int BoxId { get; set; }
        public Box Box { get; set; }

        public int OefeningId { get; set; }
        public Oefening Oefening { get; set; }

        public BoxOefening()
        {
        }

        public BoxOefening(Box box, Oefening oefening) : this()
        {
            Box = box;
            BoxId = Box.BoxId;

            Oefening = oefening;
            OefeningId = Oefening.OefeningId;
        }
    }
}