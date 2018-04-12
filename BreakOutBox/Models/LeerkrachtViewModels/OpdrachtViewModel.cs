using BreakOutBox.Models.Domain;
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

        public OpdrachtViewModel()
        {
        }

        public OpdrachtViewModel(Groep groep)
        {
            Groep = groep;
            NrHuidigeOpdracht = groep.Pad.GetProgressie()[0];
            NrTotaalOpdrachten = groep.Pad.GetProgressie()[1];
            PercentageVoltooid = (int)(((double)(NrHuidigeOpdracht - 1) / (double)NrTotaalOpdrachten) * 100);
            Opdracht = groep.Pad.GetCurrentOpdracht();
            FoutePogingen = Opdracht.FoutePogingen;
            OpdrachtIsOpgelost = groep.Pad.GetCurrentOpdracht().IsOpgelost;
            VolgendeOpdrachtIsToegankelijk = groep.Pad.GetNextOpdracht().IsToegankelijk;
            ToegangscodeVolgendeOpdracht = groep.Pad.GetNextOpdracht().Toegangscode.Code;
            Groepsantwoord = BerekenGroepsantwoord();
        }

        private double? BerekenGroepsantwoord()
        {
            switch (Opdracht.Groepsbewerking.Bewerking)
            {
                case EnumBewerking.OPTELLING:
                    return Opdracht.Oefening.Antwoord + Opdracht.Groepsbewerking.Getal;
                case EnumBewerking.AFTREKKING:
                    return Opdracht.Oefening.Antwoord - Opdracht.Groepsbewerking.Getal;
                case EnumBewerking.VERMENIGVULDIGING:
                    return Opdracht.Oefening.Antwoord * Opdracht.Groepsbewerking.Getal;
                case EnumBewerking.DELING:
                    return Opdracht.Oefening.Antwoord / Opdracht.Groepsbewerking.Getal;
            }
            return null;
        }
    }
}