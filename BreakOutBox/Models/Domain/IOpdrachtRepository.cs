using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public interface IOpdrachtRepository
    {
        List<Opdracht> GetAll();
        Opdracht GetByOpdrachtByNummer(int nummer);
        Opdracht GetByOpdrachtById(int id);
    }
}
