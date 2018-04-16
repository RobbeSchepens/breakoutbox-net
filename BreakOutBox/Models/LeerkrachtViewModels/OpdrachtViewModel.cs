using BreakOutBox.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BreakOutBox.Models.LeerkrachtViewModels
{
    public class OpdrachtViewModel
    {
        public Groep Groep { get; set; }
        public double? Groepsantwoord { get; set; }
        public int NrHuidigeOpdracht { get; set; }
        public int NrTotaalOpdrachten { get; set; }
        public int PercentageVoltooid { get; set; }
        public Opdracht Opdracht { get; set; }
        public int FoutePogingen { get; set; }
        public bool OpdrachtIsOpgelost { get; set; }
        public bool VolgendeOpdrachtIsToegankelijk { get; set; }
        public double ToegangscodeVolgendeOpdracht { get; set; }
        public string ActieVolgendeOpdracht { get; set; }
        public bool IsLaatsteOefening { get; set; }
        public bool IsTijdsOpdracht { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "{0} mag geen negatief getal zijn.")]
        public int OpgegevenMinuten { get; set; }

        public OpdrachtViewModel()
        {
        }

        public OpdrachtViewModel(Groep groep)
        {
            Groep = groep;
            NrHuidigeOpdracht = groep.Pad.GetProgressie()[0];
            NrTotaalOpdrachten = groep.Pad.GetProgressie()[1];

            if (groep.Pad.GetCurrentOpdracht().IsOpgelost)
                PercentageVoltooid = (int)(((double)(NrHuidigeOpdracht) / (double)NrTotaalOpdrachten) * 100);
            else
                PercentageVoltooid = (int)(((double)(NrHuidigeOpdracht - 1) / (double)NrTotaalOpdrachten) * 100);

            Opdracht = groep.Pad.GetCurrentOpdracht();
            IsTijdsOpdracht = Opdracht.OpdrachtBepaler is EnumOpdrachtBepaler.TIJD;
            FoutePogingen = Opdracht.FoutePogingen;
            OpdrachtIsOpgelost = groep.Pad.GetCurrentOpdracht().IsOpgelost;
            Groepsantwoord = Opdracht.BerekenCorrectAntwoord();

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