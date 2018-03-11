using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class SessieInSpelState : SessieState
    {
        public SessieInSpelState(Sessie sessie) : base(sessie)
        {
        }

        public override void Activeer()
        {
            throw new Exception("Het spel is bezig. Gelieve te deactiveren alvorens actief te maken.");
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
