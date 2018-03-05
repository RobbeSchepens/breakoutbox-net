﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class Box
    {
        public int BoxId { get; set; }
        public ICollection<Actie> Acties { get; set; }
        public ICollection<Oefening> Oefeningen { get; set; }
        public ICollection<Toegangscode> Toegangscodes { get; set; }

        public Box()
        {
        }

        public Box(ICollection<Actie> acties, ICollection<Oefening> oefeningen, ICollection<Toegangscode> toegangscodes)
        {
            Acties = acties;
            Oefeningen = oefeningen;
            Toegangscodes = toegangscodes;
        }
    }
}