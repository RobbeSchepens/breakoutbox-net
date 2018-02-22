using System.ComponentModel.DataAnnotations;

namespace BreakOutBox.Models.SessieViewModels
{
    public class ToonOpdrachtViewModel
    {
        [Display(Name = "Categorie")]
        public string Categorie { get; set; }
        [Display(Name = "Omschrijving")]
        public string Omschrijving { get; set; }
        public int VraagNummer { get; set; }
    }
}
