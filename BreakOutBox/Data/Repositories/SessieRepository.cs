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

        public Sessie GetBySessieCode(string sessieCode)
        {
            return _sessies
                .Include(e => e.Groepen)
                    .ThenInclude(e => e.Leerlingen)
                .Include(e => e.Groepen)
                    .ThenInclude(e => e.Pad)
                        .ThenInclude(e => e.Opdrachten)
                            .ThenInclude(e => e.Actie)
                .Include(e => e.Groepen)
                    .ThenInclude(e => e.Pad)
                        .ThenInclude(e => e.Opdrachten)
                            .ThenInclude(e => e.Oefening)
                                .ThenInclude(e => e.Vak)
                .Include(e => e.Groepen)
                    .ThenInclude(e => e.Pad)
                        .ThenInclude(e => e.Opdrachten)
                            .ThenInclude(e => e.Toegangscode)
                .Include(e => e.Groepen)
                    .ThenInclude(e => e.Pad)
                        .ThenInclude(e => e.Opdrachten)
                            .ThenInclude(e => e.Groepsbewerking)
                .Include(e => e.Klas)
                    .ThenInclude(e => e.Leerlingen)
                .FirstOrDefault(e => e.Code == sessieCode);
        }

        public void Add(Sessie sessie)
        {
            _sessies.Add(sessie);
        }

        public void Delete(Sessie sessie)
        {
            _sessies.Remove(sessie);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
