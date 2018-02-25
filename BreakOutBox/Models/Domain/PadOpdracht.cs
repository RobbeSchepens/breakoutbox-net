using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public class PadOpdracht
    {
        public int PadId { get; set; }
        public Pad Pad { get; set; }

        public int OpdrachtId { get; set; }
        public Opdracht Opdracht { get; set; }

        public PadOpdracht()
        {
        }

        public PadOpdracht(Pad pad, Opdracht opdracht) : this()
        {
            Pad = pad;
            PadId = Pad.PadId;

            Opdracht = opdracht;
            OpdrachtId = Opdracht.OpdrachtId;
        }
    }
}
