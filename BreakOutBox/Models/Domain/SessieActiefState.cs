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

        public override void Deactiveer(ICollection<Groep> groepen)
        {
            foreach (Groep g in groepen)
            {
                g.Ontgrendel();
            }
        }

        public override void StartSpel(ICollection<Groep> groepen)
        {
            foreach (Groep g in groepen)
            {
                g.Vergrendel();
            }
        }
    }
}
