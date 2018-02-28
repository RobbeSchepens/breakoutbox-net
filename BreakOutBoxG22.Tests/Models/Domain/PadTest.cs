using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using BreakOutBox.Models.Domain;

namespace BreakOutBoxG22.Tests.Models
{
    public class PadTest
    {
        private readonly Pad _pad1;

        public PadTest()
        {
            _pad1 = new Pad();
        }

        #region Constructor
        [Fact]
        public void NewPad_CorrectName_CreatesPad()
        {
            Pad pad = new Pad();
            Assert.Equal(0, pad.NrOfOpdrachten);
            Assert.Equal(0, pad.NrOfActies);
            Assert.Equal(0, pad.PadId);
        }
        #endregion

        #region AddOpdracht
        [Fact]
        public void AddOpdracht_NewOpdracht_AddsAOpdracht()
        {
            int nrOfOpdrachtenBeforeAdd = _pad1.NrOfOpdrachten;
            _pad1.VoegOpdrachtToe(new Opdracht(7, 234));
            Assert.Equal(nrOfOpdrachtenBeforeAdd + 1, _pad1.NrOfOpdrachten);
        }

        [Fact]
        public void AddOpdracht_OpdrachtThatHasADuplicateCode_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _pad1.VoegOpdrachtToe(new Opdracht(7, 234)));
        }
        #endregion

        #region AddActie
        [Fact]
        public void AddActie_NewOpdracht_AddsAOpdracht()
        {
            int nrOfActiesBeforeAdd = _pad1.NrOfActies;
            _pad1.VoegActieToe(new Actie("Leg de choco terug"));
            Assert.Equal(nrOfActiesBeforeAdd + 1, _pad1.NrOfActies);
        }
        #endregion

        #region DeleteOpdracht
        [Fact]
        public void DeleteOpdracht_ExistingOpdracht_DeletesTheOpdracht()
        {
            int nrOfOpdrachtenBeforeAdd = _pad1.NrOfOpdrachten;
            PadOpdracht aPadOpdracht = _pad1.PadOpdrachten.First();
            //_pad1.VerwijderOpdracht(aOpdracht);
            Assert.Equal(nrOfOpdrachtenBeforeAdd - 1, _pad1.NrOfOpdrachten);
        }

        [Fact]
        public void DeleteOpdracht_NonExistingOpdracht_ThrowsException()
        {
            Opdracht aOpdracht = new Opdracht(1, 9999);
            Assert.Throws<ArgumentException>(() => _pad1.VerwijderOpdracht(aOpdracht));
        }
        #endregion

        #region DeleteActie
        [Fact]
        public void DeleteActie_ExistingActie_DeletesTheActie()
        {
            int nrOfActiesBeforeAdd = _pad1.NrOfActies;
            PadActie aPadActie = _pad1.PadActies.First();
            //_pad1.VerwijderActie(aPadActie);
            Assert.Equal(nrOfActiesBeforeAdd - 1, _pad1.NrOfActies);
        }
        #endregion
    }
}
