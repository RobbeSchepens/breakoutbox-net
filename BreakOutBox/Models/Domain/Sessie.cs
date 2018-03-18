using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Sessie
    {
        #region Fields
        private SessieState _currentState;
        #endregion

        #region Properties
        //public int SessieId { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public Klas Klas { get; set; }
        public ICollection<Groep> Groepen { get; set; }
        public int NrOfGroepen => Groepen.Count;
        public Box Box { get; private set; } // Box uit Java met alle oefeningen in
        public int State { get; set; }
        #endregion

        #region Constructors
        public Sessie()
        {
            SwitchState(State);
        }
        public Sessie(string code, string naam, string omschrijving, ICollection<Groep> groepen, Box box, int state)
        {
            Code = code;
            Naam = naam;
            Omschrijving = omschrijving;
            Groepen = groepen;
            Box = box;
            SwitchState(state);
            State = state;
        }
        #endregion

        #region Methods
        protected void ToState(SessieState state)
        {
            _currentState = state;
        }

        public void SwitchState(int st)
        {
            switch (st)
            {
                case 0:
                    ToState(new SessieNonActiefState(this));
                    State = 0;
                    break;
                case 1:
                    ToState(new SessieActiefState(this));
                    State = 1;
                    break;
                case 2:
                    ToState(new SessieInSpelState(this));
                    State = 2;
                    break;
                case 3:
                    ToState(new SessieGeblokkeerdState(this));
                    State = 3;
                    break;
                default: goto case 0;
            }
        }

        public void Activeer()
        {
            try
            {
                _currentState.Activeer();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Deactiveer()
        {
            try
            {
                _currentState.Deactiveer(Groepen);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void StartSpel()
        {
            try
            {
                _currentState.StartSpel(Groepen);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Blokkeer()
        {
            try
            {
                _currentState.Blokkeer();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Deblokkeer()
        {
            try
            {
                _currentState.Deblokkeer();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public SessieState GetState()
        {
            return _currentState;
        }
        #endregion
    }
}
