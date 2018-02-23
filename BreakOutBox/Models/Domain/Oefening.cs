﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Oefening
    {
        public int OefeningId { get; set; }
        public string Naam { get; set; }
        public Opgave Opgave { get; set; }
        public string Antwoord { get; set; }
        public Feedback Feedback { get; set; }
        public string Groepsbewerking { get; set; }

        public Oefening(string oefeningNaam, Opgave opgave, string antwoord, Feedback feedback, string groepsbewerking)
        {
            this.Naam = oefeningNaam;
            this.Opgave = opgave;
            this.Feedback = feedback;
            this.Antwoord = antwoord;
            this.Groepsbewerking = groepsbewerking;
        }
    }
}