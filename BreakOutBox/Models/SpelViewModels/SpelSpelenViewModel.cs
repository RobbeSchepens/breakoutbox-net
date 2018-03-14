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


        //[Required]
        [Display(Name = "Toegangscode voor de volgende oefening")]
        //[Compare("55")]
        public int Toegangscode { get; set; }


        public Sessie Sessie { get; set; }
        public Groep Groep { get; set; }
        public Opdracht Opdracht { get; set; }


    
        public int AantalFouteInvoer { get; set; }      


        int _teller = 0;
       

        public SpelSpelenViewModel()
        {

        }
        public SpelSpelenViewModel(Sessie sessie, Groep groep)
        {
            this.Sessie = sessie;
            this.Groep = groep;
            this.Opdracht = GetCurrentOpdracht();

        }

        /*public SpelSpelenViewModel(Groep groep)
        {
            this.Groep = groep;         
        }*/

        public Opdracht GetCurrentOpdracht()
        {         
            return Groep.Pad.Opdrachten.ToList()[_teller];
        }


        public void VolgendeOpdracht()
        {
           this.Opdracht = Groep.Pad.Opdrachten.ToList()[_teller++];

        }


    }
}
