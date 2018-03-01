using BreakOutBox.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BreakOutBoxG22.Tests.Models
{
    public class KlasTest
    {
        private readonly Klas _klas1;

        public KlasTest()
        {
            _klas1 = new Klas();
        }

        #region Constructor
        [Fact]
        public void NewKlas_CorrectName_CreatesKlas()
        {
            Klas klas = new Klas();
            Assert.Equal(0, klas.NrOfLeerkrachten);
            Assert.Equal(0, klas.NrOfLeerlingen);
            Assert.Equal(0, klas.KlasId);
        }
        #endregion

        #region AddLeerling
        [Fact]
        public void AddLeerling_NewLeerling_AddsALeerling()
        {
            int nrOfLeerlingenBeforeAdd = _klas1.NrOfLeerlingen;
            _klas1.VoegLeerlingToe(new Leerling("Jerome", "Home"));
            Assert.Equal(nrOfLeerlingenBeforeAdd + 1, _klas1.NrOfLeerlingen);
        }

        [Fact]
        public void AddLeerling_LeerlingThatHasADuplicateName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _klas1.VoegLeerlingToe(new Leerling("Jerome", "Home")));
        }
        #endregion

        #region AddLeerkracht
        [Fact]
        public void AddLeerkracht_NewOpdracht_AddsALeerkracht()
        {
            int nrOfLeerkrachtenBeforeAdd = _klas1.NrOfLeerkrachten;
            _klas1.VoegLeerkrachtToe(new Leerkracht("Oli", "Smit"));
            Assert.Equal(nrOfLeerkrachtenBeforeAdd + 1, _klas1.NrOfLeerkrachten);
        }

        [Fact]
        public void AddOpdracht_OpdrachtThatHasADuplicateCode_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => _klas1.VoegLeerkrachtToe(new Leerkracht("Oli", "Smit")));
        }
        #endregion

        #region DeleteLeerkracht
        [Fact]
        public void DeleteOpdracht_ExistingOpdracht_DeletesTheOpdracht()
        {
            int nrOfLeerkrachtenBeforeAdd = _klas1.NrOfLeerkrachten;
            KlasLeerkracht aKlasLeerkracht = _klas1.KlasLeerkrachten.First();
            //_pad1.VerwijderOpdracht(aOpdracht);
            Assert.Equal(nrOfLeerkrachtenBeforeAdd - 1, _klas1.NrOfLeerkrachten);
        }

        [Fact]
        public void DeleteLeerkracht_NonExistingLeerkracht_ThrowsException()
        {
            Leerkracht aLeerkracht = new Leerkracht("not", "exist");
            Assert.Throws<ArgumentException>(() => _klas1.VerwijderLeerkracht(aLeerkracht));
        }
        #endregion
    }
}
