using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Groep
    {
        #region Fields
        private int _state;
        #endregion

        #region Properties
        [JsonProperty]
        public int GroepId { get; set; }
        public ICollection<Leerling> Leerlingen { get; set; }
        public Pad Pad { get; set; }
        public GroepState CurrentState { get; private set; }
        public int State
        {
            get => _state;
            set
            {
                _state = value;
                SwitchState(_state);
            }
        }
        #endregion Properties

        #region Constructors
        public Groep()
        {
        }

        public Groep(Pad pad, ICollection<Leerling> leerlingen, int state)
        {
            Pad = pad;
            Leerlingen = leerlingen;
            State = state;
        }
        #endregion Constructors

        #region Methods
        protected void ToState(GroepState state)
        {
            CurrentState = state;
        }

        public void SwitchState(int st)
        {
            switch (st)
            {
                case 0:
                    ToState(new GroepNietGekozenState(this));
                    break;
                case 1:
                    ToState(new GroepGekozenState(this));
                    break;
                case 2:
                    ToState(new GroepVergrendeldState(this));
                    break;
                case 3:
                    ToState(new GroepInSpelState(this));
                    break;
                case 4:
                    ToState(new GroepGeblokkeerdState(this));
                    break;
                default: goto case 0;
            }
        }

        public void ZetGekozen()
        {
            CurrentState.ZetGekozen();
        }

        public void ZetNietGekozen()
        {
            CurrentState.ZetNietGekozen();
        }

        public void Vergrendel()
        {
            CurrentState.Vergrendel();
        }

        public void Ontgrendel()
        {
            CurrentState.Ontgrendel();
        }

        public void ZetInSpel()
        {
            CurrentState.ZetInSpel();
        }

        public void HaalUitSpel()
        {
            CurrentState.HaalUitSpel();
        }

        public void Blokkeer()
        {
            CurrentState.Blokkeer();
        }

        public void Deblokkeer()
        {
            CurrentState.Deblokkeer();
        }

        public void VerwerkAntwoord(double inputantwoord)
        {
            CurrentState.VerwerkAntwoord(inputantwoord);
        }

        public void VerwerkToegangscode(double inputcode)
        {
            CurrentState.VerwerkToegangscode(inputcode);
        }

        public void StartVolgendeOpdracht()
        {
            CurrentState.StartVolgendeOpdracht();
        }

        public void VoegLeerlingToe(Leerling leerling)
        {
            if (Leerlingen.Count == 4)
                throw new ArgumentException("Een groep mag maximaal 4 leerlingen groot zijn.");
            Leerlingen.Add(leerling);

            // Check state 
            if (Leerlingen.Count >= 2 && Leerlingen.Count <= 4)
                ToState(new GroepGekozenState(this));
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