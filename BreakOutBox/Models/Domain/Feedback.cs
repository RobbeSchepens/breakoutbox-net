﻿namespace BreakOutBox.Models.Domain
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string Omschrijving { get; set; }


        public Feedback()
        {

        }
        public Feedback(string omschrijving)
        {
            Omschrijving = omschrijving;
        }
    }
}