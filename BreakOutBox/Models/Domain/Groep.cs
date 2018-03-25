using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Groep
    {
        #region Fields
        private GroepState _currentState;
        private int _state;
        #endregion

        #region Properties
        [JsonProperty]
        public int GroepId { get; set; }
        public ICollection<Leerling> Leerlingen { get; set; }
        public Pad Pad { get; set; }
        public int State {
            get { return _state; }
            set {
                _state = value;
                SwitchState(_state);
            }
        }
        //public int Voortgang
        //{
        //    get { return Pad.getProgressie()[1]; }
        //}
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
            _currentState = state;
        }

        public void SwitchState(int st)
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
                case 3:
                    ToState(new GroepGeblokkeerdState(this));
                    break;
                default: goto case 0;
            }
        }

        public void ZetGereed()
        {
            try
            {
                _currentState.ZetGereed();
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
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Vergrendel()
        {
            try
            {
                _currentState.Vergrendel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Ontgrendel()
        {
            try
            {
                _currentState.Ontgrendel();
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

        public void DeBlokkeer()
        {
            try
            {
                _currentState.DeBlokkeer();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public GroepState GetState()
        {
            return _currentState;
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