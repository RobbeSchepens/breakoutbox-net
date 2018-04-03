using System.ComponentModel.DataAnnotations;

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
    }
}