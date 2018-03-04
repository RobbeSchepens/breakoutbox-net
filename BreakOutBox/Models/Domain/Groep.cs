using System;
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
        public int GroepId { get; set; }
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
        public ICollection<Leerling> Leerlingen { get; set; }
        public int NrOfLeerlingen => Leerlingen.Count;
        public Pad Pad { get; set; }
        #endregion Properties

        #region Constructors
        public Groep(Pad pad)
        {
            Leerlingen = new HashSet<Leerling>();
            Pad = pad;
            ToState(new GroepNietKlaarState(this));
        }

        //public Groep(string naam) : this()
        //{
        //    Naam = naam;
        //}
        #endregion Constructors

        #region Methods
        public void VoegLeerlingToe(Leerling leerling)
        {
            if (Leerlingen.Count == 4)
                throw new ArgumentException("Een groep mag maximaal 4 leerlingen groot zijn.");
            Leerlingen.Add(leerling);
            
            // Check state 
            if (Leerlingen.Count >= 2 && Leerlingen.Count <= 4)
                ToState(new GroepKlaarState(this));
        }

        public void Vergrendel()
        {
            ToState(new GroepVergrendeldState(this));
        }

        protected void ToState(GroepState state)
        {
            _currentState = state;
        }
        #endregion Methods
    }
}