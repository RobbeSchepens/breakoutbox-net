using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Data.Repositories
{
    public class OpdrachtRepository : IOpdrachtRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Opdracht> _opdrachten;

        public OpdrachtRepository(ApplicationDbContext context)
        {
            _context = context;
            _opdrachten = context.Opdrachten;
        }

        public List<Opdracht> GetAll()
        {
            return _opdrachten.ToList();
        }

        public Opdracht GetByOpdrachtById(int id)
        {
            return _opdrachten.SingleOrDefault(c => c.OpdrachtId == id);
        }

        public Opdracht GetByOpdrachtByNummer(int nummer)
        {
            throw new NotImplementedException();
        }
    }
}
