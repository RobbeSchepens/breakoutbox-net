using BreakOutBox.Models.Domain;

namespace BreakOutBox.Models.SessieViewModels
{
    public class EditViewModel
    {
        public int State { get; set; }

        public EditViewModel()
        {
        }

        public EditViewModel(Groep g)
        {
            g.State = State;
        }
    }
}