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

                var opdrachtenPool = new List<Opdracht> {
                    new Opdracht(1, "Meetkunde Domino", "Leg de domino in de juiste volgorde (begin met Start). Noteer het laatste woord. Noteer voor elke letter van het woord de positie in het alfabet en maak de som van al die getallen. ", null),
                    new Opdracht(2, "Rationale getallen", "Zet de 5 breuken om naar rationale getallen. Maak vervolgens de som van al die rationale getallen. Met die som een berekening voer je een berekening uit waarin de volgorde der bewerkingen een rol speelt ", null),
                    new Opdracht(3, "Distributiviteit", "Werk de 5 oefeningen uit. Tel alle bekomen letterresultaten bij elkaar op en trek er 2ab van af ", null),
                    new Opdracht(4, "Vergelijkingen", "Werk 5 vergelijkingen uit die telkens een waarde voor x opleveren. Bereken het product van die getallen.  ", null),
                    new Opdracht(5, "Driehoeken", "Je krijgt een tekening met 5 driehoeken op schaal. Bereken de totale werkelijke oppervlakte en de totale werkelijke omtrek. Trek daarna het getal van de omtrek af van het getal van de oppervlakte. ", null),
                    new Opdracht(6, "Oppervlakte vierhoeken en cirkels", "5 vraagstukken i.v.m. Oppervlakte vierhoeken en cirkels: som van alle oppervlaktes zoeken ", null),
                    new Opdracht(7, "Bewerkingen met gehele getallen", "BW-quiz met oefeningen op optellen / aftrekken / delen / vermenigvuldigen: som van alle antwoorden zoeken ", null),
                    new Opdracht(8, "Alle leerstof", "Kahoot quiz over Alle leerstof: quiz blijven spelen tot de score hoger is dan … t ", null)
                };

                var groep1 = new Groep("Groep1", leerligen.GetRange(0, 4));
                var groep2 = new Groep("Groep2", leerligen.GetRange(4, 4));
                var groep3 = new Groep("Groep3", leerligen.GetRange(8, 4));
                var groep4 = new Groep("Groep4", leerligen.GetRange(12, 4));
                var groep5 = new Groep("Groep5", leerligen.GetRange(16, 4));

                var groepenInSessie = new List<Groep> { groep1, groep2, groep3, groep4, groep5 };

                groep1.OpdrachtenPad = opdrachtenPool;

                int[] volgordeOpdrachten = new int[] { 7, 6, 5, 4, 3, 2, 1, 8 };

                foreach (int elem in volgordeOpdrachten)
                {
                    groep2.OpdrachtenPad = new HashSet<Opdracht>();
                    groep2.OpdrachtenPad.Add(opdrachtenPool[elem - 1]);
                }

                volgordeOpdrachten = new int[] { 3, 5, 7, 1, 2, 4, 6, 8 };
                foreach (int elem in volgordeOpdrachten)
                {
                    groep3.OpdrachtenPad = new HashSet<Opdracht>();
                    groep3.OpdrachtenPad.Add(opdrachtenPool[elem - 1]);
                }

                volgordeOpdrachten = new int[] { 6, 2, 5, 1, 4, 7, 3, 8 };
                foreach (int elem in volgordeOpdrachten)
                {
                    groep4.OpdrachtenPad = new HashSet<Opdracht>();
                    groep4.OpdrachtenPad.Add(opdrachtenPool[elem - 1]);
                }

                volgordeOpdrachten = new int[] { 4, 3, 6, 2, 7, 5, 1, 8 };
                foreach (int elem in volgordeOpdrachten)
                {
                    groep5.OpdrachtenPad = new HashSet<Opdracht>();
                    groep5.OpdrachtenPad.Add(opdrachtenPool[elem - 1]);
                }

                Sessie sessie = new Sessie("321", "Dolfijn", "een testSessie", opdrachtenPool, groepenInSessie, null);
                _dbContext.Sessies.Add(sessie);
                _dbContext.SaveChanges();
            }
        }
    }
}
