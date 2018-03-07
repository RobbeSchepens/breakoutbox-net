using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public interface ILeerkrachtRepository
    {
        Leerkracht GetByVolledigeNaam(string voornaam, string achternaam);

        void SaveChanges();

    }


}
