using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Sessie
    {
        #region Fields
        private SessieState _currentState;

        private Box _box;
        #endregion

        #region Properties
        public int SessieId { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public Klas Klas { get; set; }
        public ICollection<Groep> Groepen { get; set; }
        public int NrOfGroepen => Groepen.Count;
        #endregion

        #region Constructors
        public Sessie()
        {
        }

        public Sessie(string code, string naam, string omschrijving, Box box)
        {
            this.Code = code;
            this.Naam = naam;
            this.Omschrijving = omschrijving;
            Groepen = new HashSet<Groep>();
            this.ToState(new SessieNietKlaarState(this));
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
            this.ToState(new SessieGestartState(this));
        }

        public void VoegGroepToe(Groep groep)
        {
            Groepen.Add(groep);
        }

        public void VerwijderGroep(Groep groep)
        {
            if (!Groepen.Contains(groep))
                throw new ArgumentException($"Groep met id {groep.GroepId} bestaat niet.");
            Groepen.Remove(groep);
        }
        #endregion
    }
}
