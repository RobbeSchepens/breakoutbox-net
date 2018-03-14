﻿using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Groep
    {
        #region Fields
        //private string _name;
        private GroepState _currentState;
        #endregion

        #region Properties
        //public string Naam {
        //    get
        //    {
        //        return _name;
        //    }
        //    private set
        //    {
        //        if (string.IsNullOrWhiteSpace(value))
        //            throw new ArgumentException("De naam van de groep mag niet leeg zijn of spaties bevatten.");
        //        _name = value;
        //    }
        //}
        public int GroepId { get; set; }
        public ICollection<Leerling> Leerlingen { get; set; }
        public int NrOfLeerlingen => Leerlingen.Count;
        public Pad Pad { get; set; }
        public int State { get; set; }
        #endregion Properties

        #region Constructors
        public Groep()
        {
            SwitchState(State);
        }

        public Groep(Pad pad, ICollection<Leerling> leerlingen, int state)
        {
            Pad = pad;
            Leerlingen = leerlingen;
            SwitchState(state);
            State = state;
        }

        //public Groep(string naam) : this()
        //{
        //    Naam = naam;
        //}
        #endregion Constructors

        #region Methods
        protected void ToState(GroepState state)
        {
            _currentState = state;
        }

        private void SwitchState(int st)
        {
            switch (st)
            {
                case 0:
                    ToState(new GroepNietGereedState(this));
                    break;
                case 1:
                    ToState(new GroepGereedState(this));
                    break;
                case 2:
                    ToState(new GroepVergrendeldState(this));
                    break;
                default: goto case 0;
            }
        }

        public void ZetGereed()
        {
            try
            {
                _currentState.ZetGereed();
                ToState(new GroepGereedState(this));
                State = 1;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void ZetNietGereed()
        {
            try
            {
                _currentState.ZetNietGereed();
                ToState(new GroepNietGereedState(this));
                State = 0;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Vergrendel()
        {
            try
            {
                _currentState.Vergrendel();
                ToState(new GroepVergrendeldState(this));
                State = 2;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Ontgrendel()
        {
            try
            {
                _currentState.Ontgrendel();
                ToState(new GroepNietGereedState(this));
                State = 0;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void VoegLeerlingToe(Leerling leerling)
        {
            if (Leerlingen.Count == 4)
                throw new ArgumentException("Een groep mag maximaal 4 leerlingen groot zijn.");
            Leerlingen.Add(leerling);

            // Check state 
            if (Leerlingen.Count >= 2 && Leerlingen.Count <= 4)
                ToState(new GroepGereedState(this));
        }

        public void VerwijderLeerling(Leerling leerling)
        {
            if (!Leerlingen.Contains(leerling))
                throw new ArgumentException($"{leerling.Voornaam} {leerling.Achternaam} bestaat niet.");
            Leerlingen.Remove(leerling);
        }
        #endregion Methods
    }
}