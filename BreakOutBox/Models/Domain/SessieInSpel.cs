using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class SessieInSpel : SessieState
    {
        public SessieInSpel(Sessie sessie) : base(sessie)
        {
        }

        public override void Activeer()
        {
            throw new Exception("Het spel kan niet gestart worden als het niet actief is.");
        }

        public override void Deactiveer()
        {
            // ...
        }

        public override void StartSpel()
        {
            throw new Exception("Het spel is al gestart.");
        }
    }
}
