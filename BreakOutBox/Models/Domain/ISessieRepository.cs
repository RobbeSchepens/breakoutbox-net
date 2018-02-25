using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public interface ISessieRepository
    {

        IEnumerable<Sessie> GetAll();
        Sessie GetSessieByCode(string sessieCode);


        void Add(Sessie sessie);
        void Delete(Sessie sessie);
        void SaveChanges();

    }
}
