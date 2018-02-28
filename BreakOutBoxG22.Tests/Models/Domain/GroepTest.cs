using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using BreakOutBox.Models.Domain;

namespace BreakOutBoxG22.Tests.Models
{
    public class GroepTest
    {
        private readonly Groep _groep1;

        public GroepTest()
        {
            _groep1 = new Groep();
            _groep1.VoegLeerlingToe(new Leerling("Flip", "Jannssenss"));
            _groep1.VoegLeerlingToe(new Leerling("Flop", "Jannssenss"));
            //_groep1.VoegPadToe(new Pad(""));
        }

        #region Constructor
        [Fact]
        public void NewGroep_CorrectName_CreatesGroep()
        {
            Groep groep = new Groep("Choco");
            Assert.Equal("Choco", groep.Naam);
            Assert.Equal(0, groep.NrOfLeerlingen);
            Assert.Equal(0, groep.NrOfPaden);
            Assert.Equal(0, groep.GroepId);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        [InlineData("01234567890123456789012345678901234567890123456789*")]
        public void NewGroep_NameIncorrect_ThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Groep(name));
        }
        #endregion

        #region AddLeerling
        [Fact]
        public void AddLeerling_NewLeerling_AddsALeerling()
        {
            int nrOfLeerlingenBeforeAdd = _groep1.NrOfLeerlingen;
            _groep1.VoegLeerlingToe(new Leerling("Jerome", "Home"));
            Assert.Equal(nrOfLeerlingenBeforeAdd + 1, _groep1.NrOfLeerlingen);
        }

        [Fact]
        public void AddLeerling_LeerlingThatHasADuplicateName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _groep1.VoegLeerlingToe(new Leerling("Jerome", "Home")));
        }

        #endregion

        #region DeleteLeerling
        [Fact]
        public void DeleteLeerling_ExistingLeerling_DeletesTheLeerling()
        {
            int nrOfLeerlingenBeforeAdd = _groep1.NrOfLeerlingen;
            Leerling aLeerling = _groep1.Leerlingen.First();
            //_groep1.VerwijderLeerling(aLeerling);
            Assert.Equal(nrOfLeerlingenBeforeAdd - 1, _groep1.NrOfLeerlingen);
        }

        [Fact]
        public void DeleteLeerling_NonExistingLeerling_ThrowsException()
        {
            Leerling aLeerling = new Leerling("Jow", "Chocow");
            //Assert.Throws<ArgumentException>(() => _groep1.VerwijderLeerling(aLeerling));
        }
        #endregion
    }
}
