using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class SessieInSpelState : SessieState
    {
        public override string Beschrijving { get; set; }
        public SessieInSpelState(Sessie sessie) : base(sessie)
        {
            Beschrijving = "In spel";
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
            _sessie.SwitchState(0);
        }

        public override void StartSpel(ICollection<Groep> groepen)
        {
            throw new Exception("Het spel is al gestart.");
        }

        public override void Blokkeer()
        {
            _sessie.SwitchState(3);
        }

        public override void Deblokkeer()
        {
            throw new Exception("Sessie is niet geblokkeerd!");
        }
    }
}
