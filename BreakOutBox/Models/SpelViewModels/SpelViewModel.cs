using BreakOutBox.Models.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BreakOutBox.Models.SpelViewModels
{
    public class SpelViewModel
    {
        //[Required(ErrorMessage = "Dit mag niet leeg zijn.")]
        public string Groepsantwoord { get; set; }
        //[Required(ErrorMessage = "Dit mag niet leeg zijn.")]
        public string Toegangscode { get; set; }
        public int NrHuidigeOpdracht { get; set; }
        public int NrTotaalOpdrachten { get; set; }
        public double PercentageVoltooid { get; set; }
        public Opdracht Opdracht { get; set; }
        public bool VolgendeOpdrachtIsToegankelijk { get; set; }
        public double ToegangscodeVolgendeOpdracht { get; set; } // Development environment

        public SpelViewModel()
        {
        }

        public SpelViewModel(Groep groep)
        {
            NrHuidigeOpdracht = groep.Pad.GetProgressie()[0];
            NrTotaalOpdrachten = groep.Pad.GetProgressie()[1];
            PercentageVoltooid = (NrHuidigeOpdracht - 1) / NrTotaalOpdrachten;
            Opdracht = groep.Pad.GetCurrentOpdracht();
            VolgendeOpdrachtIsToegankelijk = groep.Pad.GetNextOpdracht().IsToegankelijk;
            ToegangscodeVolgendeOpdracht = groep.Pad.GetNextOpdracht().Toegangscode.Code;
        }
    }
}