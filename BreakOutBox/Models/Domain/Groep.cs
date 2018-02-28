using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Groep
    {
        #region Fields
        private string _name;
        private GroepState _currentState;
        //private int leerlingCount = 0;
        #endregion

        #region Properties
        public int GroepId { get; set; }
        public string Naam {
            get
            {
                return _name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Een groep moet een naam hebben.");
                _name = value;
            }
        }
        public ICollection<Leerling> Leerlingen { get; set; }
        public int NrOfLeerlingen => Leerlingen.Count;
        public ICollection<Pad> Paden { get; set; }
        public int NrOfPaden => Paden.Count;
        #endregion Properties

        #region Constructors
        public Groep()
        {
            this.Leerlingen = new HashSet<Leerling>();
            this.Paden = new HashSet<Pad>();
            ToState(new GroepNietKlaarState(this));
        }

        public Groep(string naam) : this()
        {
            this.Naam = naam;
        }
        #endregion Constructors

        #region Methods
        public void VoegLeerlingToe(Leerling leerling)
        {
            if (Leerlingen.Count == 4)
                throw new ArgumentException("Een groep mag maximaal 4 leerlingen groot zijn.");
            Leerlingen.Add(leerling);
            
            // Check state 
            if (Leerlingen.Count >= 2 && Leerlingen.Count <= 4)
                this.ToState(new GroepKlaarState(this));
        }

        public void VoegPadToe(Pad pad)
        {
            Paden.Add(pad);
        }

        public void Vergrendel()
        {
            this.ToState(new GroepVergrendeldState(this));
        }

        protected void ToState(GroepState state)
        {
            _currentState = state;
        }
        #endregion Methods
    }
}