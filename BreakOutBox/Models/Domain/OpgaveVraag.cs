namespace BreakOutBox.Models.Domain
{
    public class OpgaveVraag
    {
        public int OpgaveVraagId { get; set; }
        public string Vraag { get; set; }

        public OpgaveVraag(string vraag)
        {
            Vraag = vraag;
        }
    }
}