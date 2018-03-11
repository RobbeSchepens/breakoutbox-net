﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public abstract class GroepState
    {
        protected Groep groep;

        protected GroepState(Groep groep)
        {
            this.groep = groep;
        }

        public abstract void ZetGereed();
        public abstract void ZetNietGereed();
    }
}
