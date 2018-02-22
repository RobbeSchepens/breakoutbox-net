using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Models.Domain
{
    public interface IGroepRepository
    {
        //DIT IS MISSCHIEN NIET NODIG
        List<Groep> GetAll();
        Groep GetByGroupName(string name);
        Groep GetGroupById(int id);
        void SaveChanges();
    }
}