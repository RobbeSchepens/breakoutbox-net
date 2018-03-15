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


        [Required(ErrorMessage ="Je moet een toegangscode ingeven")]
        [Display(Name = "Toegangscode voor de volgende oefening")]   
        public int Toegangscode { get; set; }

        public Sessie Sessie { get; set; }
        public Groep Groep { get; set; }
        public Opdracht Opdracht { get; set; }
        

        public int GroepId { get; set; }
        public int OpdrachtId { get; set; }
        public string sessieId { get; set; }

        public int TellerFouteToegangscode { get; set; }

        public SpelSpelenViewModel()
        {

        }
        public SpelSpelenViewModel(Sessie sessie, Groep groep)
        {
            this.Sessie = sessie;
            this.Groep = groep;
            this.Opdracht = Groep.Pad.Opdrachten.ToList()[0];
            TellerFouteToegangscode = 0;
            

        }

        /*public SpelSpelenViewModel(Groep groep)
        {
            this.Groep = groep;         
        }*/

       

    }
}
