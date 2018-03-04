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
        public int SessieId { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public Klas Klas { get; set; }
        public ICollection<Groep> Groepen { get; set; }
        public int NrOfGroepen => Groepen.Count;
        public Box Box { get; private set; } // Box uit Java met alle oefeningen in
        #endregion

        #region Constructors
        public Sessie()
        {
        }

        public Sessie(string code, string naam, string omschrijving, Box box)
        {
            Code = code;
            Naam = naam;
            Omschrijving = omschrijving;
            Groepen = new HashSet<Groep>();
            ToState(new SessieNietKlaarState(this));
            Box = box; 
        }
        #endregion

        #region Methods
        protected void ToState(SessieState state)
        {
            _currentState = state;
        }

        public void VergrendelGroepen()
        {
            foreach (Groep g in Groepen)
            {
                g.Vergrendel();
            }
        }

        public void StartSessie()
        {
            ToState(new SessieGestartState(this));
        }
        #endregion
    }
}
