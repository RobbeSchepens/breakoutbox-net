using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public abstract class SessieState
    {
        protected Sessie sessie;

        public SessieState(Sessie sessie)
        {
            this.sessie = sessie;
        }

        public void VergrendelGroepen()
        {

        }

        public void StartSessie()
        {

        }
    }
}
