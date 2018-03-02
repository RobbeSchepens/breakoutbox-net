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

                var leerlingen = new List<Leerling>{
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


                var groep1 = new Groep("Groep1");
                groep1.VoegLeerlingToe(leerlingen[0]);
                groep1.VoegLeerlingToe(leerlingen[1]);
                groep1.VoegLeerlingToe(leerlingen[2]);
                groep1.VoegLeerlingToe(leerlingen[3]);
                var groep2 = new Groep("Groep2");
                groep2.VoegLeerlingToe(leerlingen[4]);
                groep2.VoegLeerlingToe(leerlingen[5]);
                groep2.VoegLeerlingToe(leerlingen[6]);
                groep2.VoegLeerlingToe(leerlingen[7]);
                var groep3 = new Groep("Groep3");
                groep3.VoegLeerlingToe(leerlingen[8]);
                groep3.VoegLeerlingToe(leerlingen[9]);
                groep3.VoegLeerlingToe(leerlingen[10]);
                groep3.VoegLeerlingToe(leerlingen[11]);
                var groep4 = new Groep("Groep4");
                groep4.VoegLeerlingToe(leerlingen[12]);
                groep4.VoegLeerlingToe(leerlingen[13]);
                groep4.VoegLeerlingToe(leerlingen[14]);
                groep4.VoegLeerlingToe(leerlingen[15]);
                var groep5 = new Groep("Groep5");
                groep5.VoegLeerlingToe(leerlingen[16]);
                groep5.VoegLeerlingToe(leerlingen[17]);
                groep5.VoegLeerlingToe(leerlingen[18]);
                groep5.VoegLeerlingToe(leerlingen[19]);

                var Toegangscodes = new List<Toegangscode>();
                for(int i = 0; i <= 7; i++)
                {
                    Toegangscodes.Add(new Toegangscode(i));
                }

                var Groepsbewerkingen = new List<Groepsbewerking>();
                for (int i = 0; i <= 7; i++)
                {
                    Groepsbewerkingen.Add(new Groepsbewerking("BewerkingPlaceholder" + i.ToString()));
                }

                var Opgaven = new List<Opgave>();
                for (int i = 0; i <= 7; i++)
                {
                    Opgaven.Add(new Opgave("OpgavePlaceholder" + i.ToString()));
                }

                var Antwoorden = new List<Antwoord>();
                for (int i = 0; i <= 7; i++)
                {
                    Antwoorden.Add(new Antwoord(i));
                }

                var feedback = new Feedback("FeedbackPlaceholder");

                var Oefeningen = new List<Oefening>();
                for (int i = 0; i <= 7; i++)
                {
                    Oefeningen.Add(new Oefening("OefeningPlaceholder" + i.ToString(), Opgaven[i], Antwoorden[i], feedback, Groepsbewerkingen[i]));
                }

                var Acties = new List<Actie>();
                for (int i = 0; i <= 7; i++)
                {
                    Acties.Add(new Actie("ActiePlaceholder" + i.ToString()));
                }

                var Box = new Box(Toegangscodes, Acties, Oefeningen);


                //var TBA = new List<Opdracht> {
                //     new Opdracht(1,null,0),
                // };






















                Sessie s = new Sessie();
                _dbContext.Sessies.Add(s);
                _dbContext.SaveChanges();
            }
        }
    }
}
