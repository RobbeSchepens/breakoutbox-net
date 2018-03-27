using BreakOutBox.Models.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BreakOutBox.Models.SpelViewModels
{
    public class SpelSpelenViewModel
    {
        [Required(ErrorMessage = "Dit mag niet leeg zijn")]
        [Display(Name = "Stap 3: Geef het antwoord met de groepsbewerking")]
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
        
        // props hieronder mogen allemaal weg
        public Sessie Sessie { get; set; }
        public Groep Groep { get; set; }
        public int State { get; set; }
        //public int GroepId { get; set; }
        //public int OpdrachtId { get; set; }
        public int TellerFoutePogingen { get; set; }
        
        public SpelSpelenViewModel()
        {
            JuistGeantwoordOpgave = false;
            JuistGeantwoordtoegangscode = false;
            State = 0;
        }

        public SpelSpelenViewModel(Sessie sessie, Groep groep)
        {
        }

        public bool convertTextToBool(string text)
        {
            if (text == "True")
                return true;
            if (text == "False")
                return false;

            return false;
        }
    }
}