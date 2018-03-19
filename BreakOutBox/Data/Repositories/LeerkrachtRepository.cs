using BreakOutBox.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Data.Repositories
{
    public class LeerkrachtRepository : ILeerkrachtRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Leerkracht> _leerkrachten;

        public LeerkrachtRepository(ApplicationDbContext context)
        {
            _context = context;
            _leerkrachten = context.Leerkrachten;
        }

        public Leerkracht GetByEmail(string email)
        {
            return _leerkrachten.Where(lk => lk.Email == email).Include(lk => lk.Sessies).ThenInclude(ses => ses.Groepen).FirstOrDefault();
        }

        public Leerkracht GetByVolledigeNaam(string voornaam, string achternaam)
        {
            return _leerkrachten.Where(lk => lk.Voornaam == voornaam && lk.Achternaam == achternaam).Include(lk => lk.Sessies).ThenInclude(ses => ses.Groepen).FirstOrDefault();
        }

        

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
