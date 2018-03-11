using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class SessieNonActiefState : SessieState
    {
        public SessieNonActiefState(Sessie sessie) : base(sessie)
        {
        }

        public override void Activeer()
        {
            // ...
        }

        public override void Deactiveer(ICollection<Groep> groepen)
        {
            throw new Exception("De sessie is al non-actief.");
        }

        public override void StartSpel(ICollection<Groep> groepen)
        {
            throw new Exception("Het spel kan niet gestart worden als de sessie niet actief is.");
        }
    }
}
