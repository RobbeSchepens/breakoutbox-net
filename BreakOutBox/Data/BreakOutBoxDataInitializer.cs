using BreakOutBox.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutBox.Data
{
    public class BreakOutBoxDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public BreakOutBoxDataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {

                var leerligen = new List<Leerling>{
                    new Leerling("Andrea", "Van Dijk", null),
                    new Leerling("Henk", "Bakker", null),
                    new Leerling("Stephanie", "Mulder", null),
                    new Leerling("Tom", "De Groot", null),
                    new Leerling("Lily", "Bos", null),
                    new Leerling("Jayden", "Hendriks", null),
                    new Leerling("Pamela", "Dekker", null),
                    new Leerling("Luc", "Dijkstra", null),
                    new Leerling("Eva", "Jacobs", null),
                    new Leerling("Harry", "Vermeulen", null),

                    new Leerling("Katy", "Schouten", null),
                    new Leerling("Marcel", "Willems", null),
                    new Leerling("Rosa", "Hoekstra", null),
                    new Leerling("Bob", "Koster", null),
                    new Leerling("Sasha", "Verhoeven", null),
                    new Leerling("Thijmen", "Prins", null),
                    new Leerling("Sam", "Leunens", null),
                    new Leerling("Sarah", "VanBossche", null),
                    new Leerling("Femke", "Vanhoeke", null),
                    new Leerling("Sep", "Jacobs", null),
                };


                var groep1 = new Groep("Groep1", leerligen.GetRange(0, 4), null);
                var groep2 = new Groep("Groep2", leerligen.GetRange(4, 4), null);
                var groep3 = new Groep("Groep3", leerligen.GetRange(8, 4), null);
                var groep4 = new Groep("Groep4", leerligen.GetRange(12, 4), null);
                var groep5 = new Groep("Groep5", leerligen.GetRange(16, 4), null);


                var Acties = new List<Actie>
                {
                    new Actie(""),
                    new Actie(""),
                    new Actie(""),
                    new Actie(""),
                    new Actie(""),
                    new Actie(""),
                    new Actie(""),
                    new Actie(""),
                };


                //var opdrachten (met daarin oefeningen (met hierin opgaven)

                var opgaven = new List<Opgave>
                {
                    new Opgave("",null),
                    new Opgave("",null),
                    new Opgave("",null),
                    new Opgave("",null),
                    new Opgave("",null),
                    new Opgave("",null),
                    new Opgave("",null),
                    new Opgave("",null),
                };


                var oefeningen = new List<Oefening>
                {

                    new Oefening("",null,"",null,null),
                    new Oefening("",null,"",null,null),
                    new Oefening("",null,"",null,null),
                    new Oefening("",null,"",null,null),
                    new Oefening("",null,"",null,null),
                    new Oefening("",null,"",null,null),
                    new Oefening("",null,"",null,null),
                    new Oefening("",null,"",null,null),
                };


                var TBA = new List<Opdracht> {
                     new Opdracht(1,null,0),
                 };
























                _dbContext.Sessies.Add(sessie);
                _dbContext.SaveChanges();
            }
        }
    }
}
