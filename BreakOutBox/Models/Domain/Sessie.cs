using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Sessie
    {
        #region Fields
        private SessieState _currentState;
        private int _state;
        #endregion

        #region Properties
        [JsonProperty]
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public Klas Klas { get; set; }
        public ICollection<Groep> Groepen { get; set; }
        public Box Box { get; private set; } // Box uit Java met alle oefeningen in
        public int State
        {
            get { return _state; }
            set
            {
                SwitchState(value);
                _state = value;
            }
        }
        #endregion

        #region Constructors
        public Sessie()
        {
        }

        public Sessie(string code, string naam, string omschrijving, ICollection<Groep> groepen, Box box, int state)
        {
            Code = code;
            Naam = naam;
            Omschrijving = omschrijving;
            Groepen = groepen;
            Box = box;
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
                    break;
                case 1:
                    ToState(new SessieActiefState(this));
                    break;
                case 2:
                    ToState(new SessieInSpelState(this));
                    break;
                case 3:
                    ToState(new SessieGeblokkeerdState(this));
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
                throw e;
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
                throw e;
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
                throw e;
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
                throw e;
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
                throw e;
            }
        }

        public SessieState GetState()
        {
            return _currentState;
        }
        #endregion
    }
}
