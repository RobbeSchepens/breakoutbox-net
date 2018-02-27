using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class GroepKlaarState : GroepState
    {
        public GroepKlaarState(Groep groep) : base(groep)
        {

        }

        public void vergrendel()
        {
            base.vergrendel();
        }
    }
}
