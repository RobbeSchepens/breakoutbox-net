using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Groep
    {
        public int GroepId { get; set; }
        public string Naam { get; set; }
        public ICollection<Leerling> Leerlingen { get; set; }
        public ICollection<Pad> Paden { get; set; }
        public int Grootte { get; set; }

        private GroepState _currentState;

        private int leerlingCount = 0;

        public Groep(string naam, int grootte, ICollection<Pad> paden)
        {
            this.Naam = naam;
            this.Leerlingen = new List<Leerling>();
            this.Paden = paden;
            this.Grootte = grootte;
            toState(new GroepNietKlaarState(this));
        }

        public void voegLeerlingToe(Leerling leerling)
        {
            Leerlingen.Add(leerling);
            if(Leerlingen.Count == this.Grootte)
            {
                this.toState(new GroepKlaarState(this));
            }
        }

        public void vergrendel()
        {
            this.toState(new GroepVergrendeldState(this));
        }

        protected void toState(GroepState state)
        {
            _currentState = state;
        }
    }
}