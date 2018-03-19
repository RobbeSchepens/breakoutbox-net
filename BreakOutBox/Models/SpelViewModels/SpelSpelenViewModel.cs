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
        [Required(ErrorMessage ="Dit mag niet leeg zijn")]
        [Display(Name = "Antwoord op de oefening")]   
        public int Groepsantwoord { get; set; }

        public Sessie Sessie { get; set; }
        public Groep Groep { get; set; }
        public Opdracht Opdracht { get; set; }
        
        public int GroepId { get; set; }
        public int OpdrachtId { get; set; }
        public string sessieId { get; set; }

        public int TellerFoutePogingen { get; set; }

        public SpelSpelenViewModel()
        {
        }

        public SpelSpelenViewModel(Sessie sessie, Groep groep)
        {
            this.Sessie = sessie;
            this.Groep = groep;
            this.Opdracht = Groep.Pad.Opdrachten.ToList()[0];
            TellerFoutePogingen = 0;
        }
    }
}
