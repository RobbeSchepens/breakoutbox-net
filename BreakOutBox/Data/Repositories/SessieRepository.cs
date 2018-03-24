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
                .Include(sessie => sessie.Groepen)
                    .ThenInclude(grp => grp.Leerlingen)
                .Include(sessie => sessie.Groepen)
                    .ThenInclude(groep => groep.Pad)
                        .ThenInclude(pad => pad.Opdrachten)
                            .ThenInclude(opdr => opdr.Actie)
                .Include(sessie => sessie.Groepen)
                    .ThenInclude(groep => groep.Pad)
                        .ThenInclude(pad => pad.Opdrachten)
                            .ThenInclude(opdr => opdr.Oefening)
                                .ThenInclude(oefn => oefn.Vak)
                .Include(sessie => sessie.Groepen)
                    .ThenInclude(groep => groep.Pad)
                        .ThenInclude(pad => pad.Opdrachten)
                            .ThenInclude(opdr => opdr.Toegangscode)
                .Include(sessie => sessie.Klas)
                    .ThenInclude(k => k.Leerlingen)
                .FirstOrDefault(sessie => sessie.Code == sessieCode);
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
