using BreakOutBox.Models.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BreakOutBox.Models.SpelViewModels
{
    public class SpelSpelenViewModel
    {
        [Required(ErrorMessage = "Dit mag niet leeg zijn")]
        [Display(Name = "Stap 3: Vul je bekomen resultaat hieronder in.")]
        public string Groepsantwoord { get; set; }

        public bool JuistGeantwoordOpgave { get; set; }
        public string JuistGeantwoordOpgaveString { get; set; }

        public bool JuistGeantwoordtoegangscode { get; set; }
        public string JuistGeantwoordtoegangscodeString { get; set; }

        public List<int> ProgressieInPad { get; set; }
        public Opdracht Opdracht { get; set; }
        public string ToegangscodeVolgendeOefening { get; set; }

        public int GroepId { get; set; }
        public string SessieCode { get; set; }
        
        public SpelSpelenViewModel()
        {
            JuistGeantwoordOpgave = false;
            JuistGeantwoordtoegangscode = false;
        }

        public SpelSpelenViewModel(Sessie sessie, Groep groep)
        {
        }

        public bool ConvertTextToBool(string text)
        {
            if (text == "True")
                return true;
            if (text == "False")
                return false;
            return false;
        }
    }
}