﻿using System;
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
        public int State { get; set; }
        #endregion

        #region Constructors
        public Sessie()
        {
        }

        public Sessie(string code, string naam, string omschrijving, ICollection<Groep> groepen, Box box)
        {
            Code = code;
            Naam = naam;
            Omschrijving = omschrijving;
            Groepen = groepen;
            Box = box;
            ToState(new SessieNonActiefState(this));
            State = 0; // nog in constructor toevoegen 
        }
        #endregion

        #region Methods
        protected void ToState(SessieState state)
        {
            _currentState = state;
        }

        public void Activeer()
        {
            try
            {
                _currentState.Activeer();
                ToState(new SessieActiefState(this));
                State = 1;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Deactiveer()
        {
            try
            {
                _currentState.Activeer();
                ToState(new SessieNonActiefState(this));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void StartSpel()
        {
            try
            {
                foreach (Groep g in Groepen)
                {
                    g.Vergrendel();
                }

                ToState(new SessieInSpel(this));
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}
