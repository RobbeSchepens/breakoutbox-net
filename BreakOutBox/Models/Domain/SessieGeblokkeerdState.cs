using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class SessieGeblokkeerdState : SessieState
    {
        public override string Beschrijving { get; set; }

        public SessieGeblokkeerdState(Sessie sessie) : base(sessie)
        {
            Beschrijving = "Geblokkeerd";
        }

        public override void Deblokkeer()
        {
            _sessie.State = 2;
        }

        public override void Activeer()
        {
            throw new Exception("De sessie is geblokkeerd!");
        }

        public override void Blokkeer()
        {
            throw new Exception("Sessie is al geblokkeerd");
        }

        public override void Deactiveer(ICollection<Groep> groepen)
        {
            throw new Exception("De sessie is geblokkeerd!");
        }

        public override void StartSpel(ICollection<Groep> groepen)
        {
            throw new Exception("Sessie is al gestart!");
        }
    }
}
