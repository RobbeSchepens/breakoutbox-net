using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Data.Repositories
{
    public class GroepRepository : IGroepRepository
    {
        // DIT IS MISSCHIEN NIET NODIG
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Groep> _groepen;

        public GroepRepository(ApplicationDbContext context)
        {
            _context = context;
            _groepen = context.Groepen;
        }

        public List<Groep> GetAll()
        {
            return _groepen.Include(c => c.GroepsLeden).Include(c => c.OpdrachtenPad).ToList();
        }

        public Groep GetByGroupName(string name)
        {
            return _groepen.Include(l => l.GroepsLeden).FirstOrDefault(s => s.GroepsNaam == name);
        }

        public Groep GetGroupById(int id)
        {
            return _groepen.Include(c => c.GroepsLeden).SingleOrDefault(c => c.GroepId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
