using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Groep
    {
        #region Fields
        //private string _name;
        private GroepState _currentState;
        private int _state;
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
        public int State {
            get { return _state; }
            set {
                _state = value;
                SwitchState(value);
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

        public void SwitchState(int st)
        {
            switch (st)
            {
                case 0:
                    ToState(new GroepNietGereedState(this));
                    State = 0;
                    break;
                case 1:
                    ToState(new GroepGereedState(this));
                    State = 1;
                    break;
                case 2:
                    ToState(new GroepVergrendeldState(this));
                    State = 2;
                    break;
                case 3:
                    ToState(new GroepGeblokkeerdState(this));
                    State = 3;
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
                throw;
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
                throw;
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

        public void DeBlokkeer()
        {
            try
            {
                _currentState.DeBlokkeer();
            }
            catch (Exception e)
            {
                throw;
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