using BreakOutBox.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.SpelViewModels
{
    public class SpelSpelenViewModel
    {
        public string SessieCode { get; set; }
        public int GroepId { get; set; }
        public Groep Groep { get; set; }
        public Pad Pad => Groep.Pad;  
        public int AantalFouteInvoer { get; set; }      
        public int OpdrachtNummer { get; set; }


        int _teller = 0; 
        Opdracht _currentOpdracht;

        public SpelSpelenViewModel()
        {

        }
        public SpelSpelenViewModel(string sessieCode, int groepId)
        {
            this.SessieCode = sessieCode;
            this.GroepId = groepId;
        }

        /*public SpelSpelenViewModel(Groep groep)
        {
            this.Groep = groep;         
        }*/

        public Opdracht GetCurrentOpdracht()
        {         
            return Pad.Opdrachten.ToList()[_teller];
        }


        public Opdracht GetVolgendeOpdracht()
        {
            _teller++;
            return Pad.Opdrachten.ToList()[_teller];
        }


    }
}
