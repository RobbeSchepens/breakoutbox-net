using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BreakOutBox.Models.Domain;

namespace BreakOutBox.Models.SessieViewModels
{
    public class ToonGroepenInSessieViewModel
    {
        public ICollection<Groep> GroepenInSessie { get; set; }
        [Display(Name = "Groepsnaam:")]

        public string HuidigeSessieCode { get; set; }
    }
}
