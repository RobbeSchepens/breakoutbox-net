namespace BreakOutBox.Models.Domain
{
    public class BoxToegangscode
    {
        public int BoxId { get; set; }
        public Box Box { get; set; }

        public int ToegangscodeId { get; set; }
        public Toegangscode Toegangscode { get; set; }

        public BoxToegangscode()
        {
        }

        public BoxToegangscode(Box box, Toegangscode toegangscode) : this()
        {
            Box = box;
            BoxId = Box.BoxId;

            Toegangscode = toegangscode;
            ToegangscodeId = Toegangscode.ToegangscodeId;
        }
    }
}