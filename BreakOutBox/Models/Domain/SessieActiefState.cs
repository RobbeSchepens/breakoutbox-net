using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class SessieActiefState : SessieState
    {
        public override string Beschrijving { get; set; }

        public SessieActiefState(Sessie sessie) : base(sessie)
        {
            Beschrijving = "Actief";
        }

        public override void Activeer()
        {
            throw new Exception("De sessie is al actief.");
        }

        public override void Deactiveer(ICollection<Groep> groepen)
        {
            //foreach (Groep g in groepen)
            //{
            //    g.Vergrendel();
            //}
            _sessie.State = 0;
        }

        public override void StartSpel(ICollection<Groep> groepen)
        {
            //foreach (Groep g in groepen)
            //{
            //    g.Vergrendel();
            //}
            _sessie.State = 2;
        }

        public override void Blokkeer()
        {
            _sessie.State = 3;
        }

        public override void Deblokkeer()
        {
            throw new Exception("Sessie is niet geblokkeerd!");
        }
    }
}
