using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Sessie
    {
        #region Fields
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
        public bool GebruiktTimer { get; private set; } // False = 3 pogingen per opdracht. True = 30 minuten per opdracht. 
        public SessieState CurrentState { get; private set; }
        public int State
        {
            get => _state;
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

        public Sessie(string code, string naam, string omschrijving, ICollection<Groep> groepen, Box box, bool gebruiktTimer, int state)
        {
            Code = code;
            Naam = naam;
            Omschrijving = omschrijving;
            Groepen = groepen;
            Box = box;
            GebruiktTimer = gebruiktTimer;
            State = state;
        }
        #endregion

        #region Methods
        protected void ToState(SessieState state)
        {
            CurrentState = state;
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
            CurrentState.Activeer();
        }

        public void Deactiveer()
        {
            CurrentState.Deactiveer();
        }

        public void StartSpel()
        {
            CurrentState.StartSpel();
        }

        public void HaalUitSpel()
        {
            CurrentState.HaalUitSpel();
        }

        public void Blokkeer()
        {
            CurrentState.Blokkeer(Groepen);
        }

        public void Deblokkeer()
        {
            CurrentState.Deblokkeer(Groepen);
        }
        #endregion
    }
}
