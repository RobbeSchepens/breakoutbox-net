using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class SessieNonActiefState : SessieState
    {
        public override string Beschrijving { get; set; }
        public SessieNonActiefState(Sessie sessie) : base(sessie)
        {
            Beschrijving = "Inactief";
        }

        public override void Activeer()
        {
            _sessie.SwitchState(1);
        }

        public override void Deactiveer(ICollection<Groep> groepen)
        {
            throw new Exception("De sessie is al non-actief.");
        }

        public override void StartSpel(ICollection<Groep> groepen)
        {
            throw new Exception("Het spel kan niet gestart worden als de sessie niet actief is.");
        }

        public override void Blokkeer()
        {
            throw new Exception("Sessie is niet actief!");
        }

        public override void Deblokkeer()
        {
            throw new Exception("Sessie is niet geblokkeerd!");
        }
    }
}