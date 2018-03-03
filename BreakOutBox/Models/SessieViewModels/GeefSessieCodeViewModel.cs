using BreakOutBox.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.SessieViewModels
{
    public class IndexViewModel
    {
        [Required(ErrorMessage = "{0} is verplicht in te vullen")]
        public string SessieCode { get; set; }


        public IndexViewModel()
        {

        }
    }
}


