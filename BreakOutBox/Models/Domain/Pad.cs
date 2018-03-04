﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Pad
    {
        public int PadId { get; set; }
        public ICollection<Opdracht> Opdrachten { get; set; }

        public Pad(ICollection<Opdracht> opdrachten)
        {
            Opdrachten = opdrachten;
        }
    }
}
