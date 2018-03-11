using BreakOutBox.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
