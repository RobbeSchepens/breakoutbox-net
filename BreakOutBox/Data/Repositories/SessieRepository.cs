using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Data.Repositories
{
    public class SessieRepository : ISessieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Sessie> _sessies;

        public SessieRepository(ApplicationDbContext context)
        {
            _context = context;
            _sessies = context.Sessies;
        }

        public IEnumerable<Sessie> GetAll()
        {
            return _sessies.ToList();
        }

        public Sessie GetByCode(string sessieCode)
        {
            return _sessies.Include(t => t.Groepen).FirstOrDefault(s => s.UniekeCode == sessieCode);
        }

        public ICollection<Groep> getGroupsBySessieCode(string sessieCode)
        {
            return _sessies.Include(g => g.Groepen).Include(g => g.OpdrachtenPool).FirstOrDefault(s => s.UniekeCode == sessieCode).Groepen;
        }

        public void Add(Sessie sessie)
        {
            throw new NotImplementedException();
        }

        public void Delete(Sessie sessie)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
