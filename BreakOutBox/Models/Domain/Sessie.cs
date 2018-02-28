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
            this.ToState(new SessieNietKlaarState(this));
        }

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

        public void VoegLeerlingToe(int id, Leerling leerling)
        {
            Groepen[id].VoegLeerlingToe(leerling);
        }
    }
}
