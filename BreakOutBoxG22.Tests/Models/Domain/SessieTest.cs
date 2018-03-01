using System;
using System.Linq;
using Xunit;
using BreakOutBox.Models.Domain;

namespace BreakOutBoxG22.Tests.Models
{
    public class SessieTest
    {
        private readonly Sessie _sessie1;

        public SessieTest()
        {
            _sessie1 = new Sessie();
            _sessie1.VoegGroepToe(new Groep());
        }

        #region Constructor
        [Fact]
        public void NewSessie_CorrectName_CreatesSessie()
        {
            Sessie sessie = new Sessie("ABC123", "Maandagochtend", "De volgende sessie maandag");
            Assert.Equal("Maandagochtend", sessie.Naam);
            Assert.Equal("ABC123", sessie.Code);
            Assert.Equal(0, sessie.SessieId);
            Assert.Equal(0, sessie.NrOfGroepen);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(" \t \n \r \t   ")]
        [InlineData("01234567890123456789012345678901234567890123456789*")]
        public void NewSessie_NameIncorrect_ThrowsException(string name)
        {
            Assert.Throws<ArgumentException>(() => new Sessie("BCD123", name, "De volgende sessie dinsdag"));
        }
        #endregion

        #region AddGroep
        [Fact]
        public void AddGroep_NewLeerling_AddsAGroep()
        {
            int nrOfGroepenBeforeAdd = _sessie1.NrOfGroepen;
            _sessie1.VoegGroepToe(new Groep());
            Assert.Equal(nrOfGroepenBeforeAdd + 1, _sessie1.NrOfGroepen);
        }
        #endregion

        #region DeleteGroep
        [Fact]
        public void DeleteGroep_ExistingGroep_DeletesTheGroep()
        {
            int nrOfGroepenBeforeAdd = _sessie1.NrOfGroepen;
            Groep aGroep = _sessie1.Groepen.First();
            _sessie1.VerwijderGroep(aGroep);
            Assert.Equal(nrOfGroepenBeforeAdd - 1, _sessie1.NrOfGroepen);
        }
        #endregion
    }
}
