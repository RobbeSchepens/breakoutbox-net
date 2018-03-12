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
                .Include(s => s.Groepen)
                    .ThenInclude(grp => grp.Leerlingen)
                .Include(a => a.Groepen).ThenInclude(b => b.Pad)
                .Include(s => s.Klas)
                     .ThenInclude(k => k.Leerlingen)
                .FirstOrDefault(s => s.Code == sessieCode);


            /* return _sessies
                 .Include(s => s.Klas)
                     .ThenInclude(k => k.Leerlingen)
                 .Include(s => s.Klas)
                     .ThenInclude(k => k.KlasLeerkrachten)
                 .Include(s => s.Groepen)
                     .ThenInclude(grp => grp.Leerlingen)
                 .Include(s => s.Groepen)
                     .ThenInclude(grp => grp.Paden)
                     .ThenInclude(pad => pad.Opdrachten)
                     .ThenInclude(opdr => opdr.Oefeningen)
                     .ThenInclude(oef => oef.Opgave)
                     .ThenInclude(Opgave => Opgave.Vragen)
                 .Include(s => s.Groepen)
                     .ThenInclude(grp => grp.Paden)
                     .ThenInclude(pad => pad.Opdrachten)
                     .ThenInclude(opdr => opdr.Oefeningen)
                     .ThenInclude(oef => oef.Feedback)
                 .Include(s => s.Groepen)
                     .ThenInclude(grp => grp.Paden)
                     .ThenInclude(pad => pad.Opdrachten)
                     .ThenInclude(opdr => opdr.Oefeningen)
                     .ThenInclude(oef => oef.Groepsbewerkingen)

                 .Include(s => s.Groepen)
                     .ThenInclude(grp => grp.Paden)
                     .ThenInclude(pad => pad.Acties)
                 .FirstOrDefault(s => s.Code == sessieCode);*/
        }

        public ICollection<Sessie> GetSessiesByLeerkracht(Leerkracht leerkracht)
        {

   
            List<Sessie> sessiesMetKlasEnleerkracht = _sessies.Include(g => g.Groepen).Include(k => k.Klas).ThenInclude(l => l.KlasLeerkrachten).ThenInclude(kl => kl.Leerkracht).ToList();
            List<Sessie> SessiesVanLeerkracht = sessiesMetKlasEnleerkracht.Where(s => s.Klas.Leerkrachten.ToList().Contains(leerkracht)).ToList();
           

          
           
            return SessiesVanLeerkracht;

         
         
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
