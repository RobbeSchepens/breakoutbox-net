using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.SpelViewModels
{
    public class SpelSpelenViewModel
    {
        [Required(ErrorMessage = "Dit mag niet leeg zijn")]
        [Display(Name = "Antwoord op de oefening")]
        public string Groepsantwoord { get; set; }
        public bool JuistGeantwoordOpgave { get; set; }
        public bool JuistGeantwoordtoegangscode { get; set; }
        public List<int> ProgressieInPad { get; set; }
        public Opdracht Opdracht { get; set; }
        public string ToegangscodeVolgendeOefening { get; set; }


        public int GroepId { get; set; }

        /*public Sessie Sessie { get; set; }
        public Groep Groep { get; set; }
        p*/

        /*public int GroepId { get; set; }
        public int OpdrachtId { get; set; }
        public string sessieId { get; set; }*/

        /*public int TellerFoutePogingen { get; set; }
        */
        public SpelSpelenViewModel()
        {
            JuistGeantwoordOpgave = false;
            JuistGeantwoordtoegangscode = false;
        }

        public SpelSpelenViewModel(Sessie sessie, Groep groep)
        {
        }
    }
}
