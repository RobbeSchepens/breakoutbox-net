using System;
using System.Collections.Generic;

namespace BreakOutBox.Models.Domain
{
    public class Sessie
    {
        public int SessieId { get; set; }
        public string Code { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public Klas Klas { get; set; }
        public IList<Groep> Groepen { get; set; }

        private SessieState _currentState;

        public Sessie()
        {
        }

        public Sessie(string code, string naam, string omschrijving, Klas klas, IList<Groep> groepen)
        {
            this.Code = code;
            this.Naam = naam;
            this.Omschrijving = omschrijving;
            this.Klas = klas;
            this.Groepen = groepen;
            this.toState(new SessieNietKlaarState(this));
        }

        protected void toState(SessieState state)
        {
            _currentState = state;
        }

        public void vergrendelGroepen()
        {
            foreach (Groep g in Groepen)
            {
                g.vergrendel();
            }
        }

        public void startSessie()
        {
            this.toState(new SessieGestartState(this));
        }

        public void voegLeerlingToe(int id, Leerling leerling)
        {
            Groepen[id].voegLeerlingToe(leerling);
        }
    }
}
