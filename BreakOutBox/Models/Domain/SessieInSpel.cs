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

        public override void Deactiveer(ICollection<Groep> groepen)
        {
            foreach (Groep g in groepen)
            {
                g.Ontgrendel();
            }
        }

        public override void StartSpel(ICollection<Groep> groepen)
        {
            throw new Exception("Het spel is al gestart.");
        }
    }
}
