using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class SessieActiefState : SessieState
    {
        public SessieActiefState(Sessie sessie) : base(sessie)
        {
        }

        public override void Activeer()
        {
            throw new Exception("De sessie is al actief.");
        }

        public override void Deactiveer()
        {
            // ...
        }

        public override void StartSpel()
        {
            // ...
        }
    }
}
