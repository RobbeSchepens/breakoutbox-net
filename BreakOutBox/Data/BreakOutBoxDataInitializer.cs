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

                var Groepsbewerkingen = new List<Groepsbewerking>()
                {
                    new Groepsbewerking("GroepsbewerkingPlaceholder"),
                };

                var OpgaveVragen = new List<OpgaveVraag>()
                {
                    new OpgaveVraag("VraagPlaceholder"),
                };

                var opgaven = new List<Opgave>
                {
                    new Opgave("Opgave1", OpgaveVragen),
                    new Opgave("Opgave2", OpgaveVragen),
                    new Opgave("Opgave3", OpgaveVragen),
                    new Opgave("Opgave4", OpgaveVragen),
                    new Opgave("Opgave5", OpgaveVragen),
                    new Opgave("Opgave6", OpgaveVragen),
                    new Opgave("Opgave7", OpgaveVragen),
                    new Opgave("Opgave8", OpgaveVragen),
                };

                var feedback = new Feedback("FeedbackPlaceholder");

                var oefeningen = new List<Oefening>();

                foreach(Opgave o in opgaven)
                {
                    oefeningen.Add(new Oefening("OefeningPlaceHolder", o, "AntwoordPlaceholder", feedback, Groepsbewerkingen));
                }


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
