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
        [Required(ErrorMessage = "Je bent de sessiecode vergeten opgeven!")]
        [Display(Name = "Sessiecode")]
        [DataType(DataType.Text)]
        public string SessieCode { get; set; }
        
        public IndexViewModel()
        {
        }
       /* public IndexViewModel(Sessie s)
        {
            s.Code = SessieCode;
        }*/
    }
}


