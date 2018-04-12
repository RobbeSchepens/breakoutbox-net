using BreakOutBox.Models.Domain;
using System;
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
        public int PercentageVoltooid { get; set; }
        public Opdracht Opdracht { get; set; }
        public bool VolgendeOpdrachtIsToegankelijk { get; set; }
        public double ToegangscodeVolgendeOpdracht { get; set; }
        public string ActieVolgendeOpdracht { get; set; }
        public bool IsLaatsteOefening { get; set; }

        public SpelViewModel()
        {
        }

        public SpelViewModel(Groep groep)
        {
            NrHuidigeOpdracht = groep.Pad.GetProgressie()[0];
            NrTotaalOpdrachten = groep.Pad.GetProgressie()[1];

            if (groep.Pad.GetCurrentOpdracht().IsOpgelost)
                PercentageVoltooid = (int)(((double)(NrHuidigeOpdracht) / (double)NrTotaalOpdrachten) * 100);
            else
                PercentageVoltooid = (int)(((double)(NrHuidigeOpdracht - 1) / (double)NrTotaalOpdrachten) * 100);

            Opdracht = groep.Pad.GetCurrentOpdracht();

            try
            {
                VolgendeOpdrachtIsToegankelijk = groep.Pad.GetNextOpdracht().IsToegankelijk;
                ToegangscodeVolgendeOpdracht = groep.Pad.GetNextOpdracht().Toegangscode.Code;
                ActieVolgendeOpdracht = groep.Pad.GetNextOpdracht().Actie.Omschrijving;
            }
            catch (ArgumentOutOfRangeException) // laatste oefening
            {
                IsLaatsteOefening = true;
            }
        }
    }
}