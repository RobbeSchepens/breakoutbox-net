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
                    new Leerling("Andrea", "Van Dijk"),
                    new Leerling("Henk", "Bakker"),
                    new Leerling("Stephanie", "Mulder"),
                    new Leerling("Tom", "De Groot"),
                    new Leerling("Lily", "Bos"),
                    new Leerling("Jayden", "Hendriks"),
                    new Leerling("Pamela", "Dekker"),
                    new Leerling("Luc", "Dijkstra"),
                    new Leerling("Eva", "Jacobs"),
                    new Leerling("Harry", "Vermeulen"),

                    new Leerling("Katy", "Schouten"),
                    new Leerling("Marcel", "Willems"),
                    new Leerling("Rosa", "Hoekstra"),
                    new Leerling("Bob", "Koster"),
                    new Leerling("Sasha", "Verhoeven"),
                    new Leerling("Thijmen", "Prins"),
                    new Leerling("Sam", "Leunens"),
                    new Leerling("Sarah", "VanBossche"),
                    new Leerling("Femke", "Vanhoeke"),
                    new Leerling("Sep", "Jacobs"),
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


















                Sessie s = new Sessie();
                _dbContext.Sessies.Add(s);
                _dbContext.SaveChanges();
            }
        }
    }
}
