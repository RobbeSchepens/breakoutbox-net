﻿using BreakOutBox.Models.Domain;
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
                #region LeerlingenAanmaken
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
                #endregion

                #region BoxAanmaken
                var toegangscodes = new List<Toegangscode> { // deze code geeft aan wat je volgende oefening is (bv. de code die je in een balon terugvind)


               
                new Toegangscode(100),
                new Toegangscode(101),
                new Toegangscode(102),
                new Toegangscode(103),
                new Toegangscode(104),
                new Toegangscode(105),
                new Toegangscode(106),
                new Toegangscode(107),

                new Toegangscode(108),
                new Toegangscode(109),
                new Toegangscode(110),
                new Toegangscode(111),
                new Toegangscode(112),
                new Toegangscode(113),
                new Toegangscode(114),
                new Toegangscode(115),

                new Toegangscode(116),
                new Toegangscode(117),
                new Toegangscode(118),
                new Toegangscode(119),
                new Toegangscode(120),
                new Toegangscode(121),
                new Toegangscode(122),
                new Toegangscode(123),

                new Toegangscode(124),
                new Toegangscode(125),
                new Toegangscode(126),
                new Toegangscode(127),
                new Toegangscode(128),
                new Toegangscode(129),
                new Toegangscode(130),
                new Toegangscode(131),

                new Toegangscode(132),
                new Toegangscode(133),
                new Toegangscode(134),
                new Toegangscode(135),
                new Toegangscode(136),
                new Toegangscode(137),
                new Toegangscode(138),
                new Toegangscode(139)


            };

                var acties = new List<Actie> { // de mogelijke acties dat je moet ondernemen (in een balon prikken, telefoonboek opendoen)
                    new Actie(""),
                    new Actie(""),
                    new Actie(""),
                    new Actie(""),
                    new Actie(""),
                    new Actie(""),
                    new Actie(""),
                    new Actie(""),
                };

                var oefeningen = new List<Oefening> { // dit zijn de oefeningen die in de sessie gebruikt worden
                    new Oefening("Oefening1", "oefening1.pdf", 10, ""),
                    new Oefening("Oefening2", "oefening2.pdf", 11, ""),
                    new Oefening("Oefening3", "oefening3.pdf", 12, ""),
                    new Oefening("Oefening4", "oefening4.pdf", 13, ""),
                    new Oefening("Oefening5", "oefening5.pdf", 14, ""),
                    new Oefening("Oefening6", "oefening6.pdf", 15, ""),
                    new Oefening("Oefening7", "oefening7.pdf", 16, ""),
                    new Oefening("Oefening8", "oefening8.pdf", 17, "")
                };


                #region GroepsBewerkingAanOefeningenToekennen
                var lijstMetGroepsbewerkingen = new List<String>{ // lijst met de mogelijke groepsbewerkingen
                   "+259",
                   "",
                   "",
                   "",
                   "",
                   "",
                   "",
                   "",

                   "",
                   "",
                   "",
                   "",
                   "",
                   "",
                   "",
                   "",

                   "",
                   "",
                   "",
                   "",
                   "",
                   "",
                   "",
                   "",

                    "",
                   "",
                   "",
                   "",
                   "",
                   "",
                   "",
                   "",

                    "",
                   "",
                   "",
                   "",
                   "",
                   "",
                   "",
                   "",
                };


                oefeningen[0].Groepsbewerking = lijstMetGroepsbewerkingen[0]; //op deze manier verder doen

                
                #endregion


                Box box = new Box(acties, oefeningen, toegangscodes);
                #endregion

               



                #region OpdrachtenMaken
                var act = box.Acties.ToList();
                var oef = box.Oefeningen.ToList();
                var toe = box.Toegangscodes.ToList();

                var opdrachtenGroep1 = new List<Opdracht>{ // lijst met alle opdrachten van groep1 (1,2, 3, 4, 5, 6, 7, 8)             
                    new Opdracht(1,act[0],oef[0],toe[0]),
                    new Opdracht(2,act[1],oef[1],toe[1]),
                    new Opdracht(3,act[2],oef[2],toe[2]),
                    new Opdracht(4,act[3],oef[3],toe[3]),
                    new Opdracht(5,act[4],oef[4],toe[4]),
                    new Opdracht(6,act[5],oef[5],toe[5]),
                    new Opdracht(7,act[6],oef[6],toe[6]),
                    new Opdracht(8,act[7],oef[7],toe[7])
                };
                _dbContext.SaveChanges();

                var opdrachtenGroep2 = new List<Opdracht>{ // lijst met alle opdrachten van groep2 (7, 6, 5, 4, 3, 2, 1, 8)
                    new Opdracht(9,null,oef[6],toe[8]),
                    new Opdracht(10,null,oef[5],toe[9]),
                    new Opdracht(11,null,oef[4],toe[10]),
                    new Opdracht(12,null,oef[3],toe[11]),
                    new Opdracht(13,null,oef[2],toe[12]),
                    new Opdracht(14,null,oef[1],toe[13]),
                    new Opdracht(15,null,oef[0],toe[14]),
                    new Opdracht(16,null,oef[7],toe[15])
                };
                _dbContext.SaveChanges();

                var opdrachtenGroep3 = new List<Opdracht>{ // lijst met alle opdrachten van groep3 (3, 5, 7, 1, 2, 4, 6, 8)
                    new Opdracht(17,null,oef[2],toe[16]),
                    new Opdracht(18,null,oef[4],toe[17]),
                    new Opdracht(19,null,oef[6],toe[18]),
                    new Opdracht(20,null,oef[0],toe[19]),
                    new Opdracht(21,null,oef[1],toe[20]),
                    new Opdracht(22,null,oef[3],toe[21]),
                    new Opdracht(23,null,oef[5],toe[22]),
                    new Opdracht(24,null,oef[7],toe[23])
                };
                _dbContext.SaveChanges();

                var opdrachtenGroep4 = new List<Opdracht>{ // lijst met alle opdrachten van groep4 ( 6, 2, 5, 1, 4, 7, 3, 8 )
                    new Opdracht(25,null,oef[5],toe[24]),
                    new Opdracht(26,null,oef[1],toe[25]),
                    new Opdracht(27,null,oef[4],toe[26]),
                    new Opdracht(28,null,oef[0],toe[27]),
                    new Opdracht(29,null,oef[3],toe[28]),
                    new Opdracht(30,null,oef[6],toe[29]),
                    new Opdracht(31,null,oef[2],toe[30]),
                    new Opdracht(32,null,oef[7],toe[31])
                };
                _dbContext.SaveChanges();

                var opdrachtenGroep5 = new List<Opdracht>{ // lijst met alle opdrachten van groep5 (4, 3, 6, 2, 7, 5, 1, 8)
                    new Opdracht(33,null,oef[3],toe[32]),
                    new Opdracht(34,null,oef[2],toe[33]),
                    new Opdracht(35,null,oef[5],toe[34]),
                    new Opdracht(36,null,oef[1],toe[35]),
                    new Opdracht(37,null,oef[6],toe[36]),
                    new Opdracht(38,null,oef[4],toe[37]),
                    new Opdracht(39,null,oef[0],toe[38]),
                    new Opdracht(40,null,oef[7],toe[39])
                };

               
             


                _dbContext.SaveChanges();
                #endregion

                #region PadenAanmaken
                var paden = new List<Pad> { // elk pad heeft zijn eigen volgorde van vragen (region: LijstenMetOpdrachtenPerGroep)
                    new Pad(opdrachtenGroep1),
                    new Pad(opdrachtenGroep2),
                    new Pad(opdrachtenGroep3),
                    new Pad(opdrachtenGroep4),
                    new Pad(opdrachtenGroep5)
                };
                _dbContext.SaveChanges();
                #endregion

                #region LeerlingenInGroepenSteken
                var groepen = new List<Groep> {
                  new Groep(paden[0], leerlingen.GetRange(0, 4)),
                  new Groep(paden[1], leerlingen.GetRange(4, 4)),
                  new Groep(paden[2], leerlingen.GetRange(8, 4)),
                  new Groep(paden[3], leerlingen.GetRange(12, 4)),
                  new Groep(paden[4], leerlingen.GetRange(16, 4))
                };
                #endregion
                
                #region KlasEnLeerkracht
                Leerkracht lk = new Leerkracht("Tom", "Deveylder");
                var k = new Klas();
                k.Leerlingen = leerlingen;
                var leerkrachten = new List<KlasLeerkracht> {
                   new KlasLeerkracht(k,lk)
                };
                #endregion

                // k.Leerkrachten.ToList().Add(leerkrachten[0]);

                var s = new Sessie("ABC", "Sessie1", "Een testSessie", groepen, box);
                s.Klas = k;

                #region Comments OLD
                //var Toegangscodes = new List<Toegangscode>();
                //for (int i = 0; i <= 7; i++)
                //{
                //    Toegangscodes.Add(new Toegangscode(i));
                //}

                //var Groepsbewerkingen = new List<Groepsbewerking>();
                //for (int i = 0; i <= 7; i++)
                //{
                //    Groepsbewerkingen.Add(new Groepsbewerking("BewerkingPlaceholder" + i.ToString()));
                //}

                //var Opgaven = new List<Opgave>();
                //for (int i = 0; i <= 7; i++)
                //{
                //    Opgaven.Add(new Opgave("OpgavePlaceholder" + i.ToString()));
                //}

                //var Antwoorden = new List<Antwoord>();
                //for (int i = 0; i <= 7; i++)
                //{
                //    Antwoorden.Add(new Antwoord(i));
                //}

                //var feedback = new Feedback("FeedbackPlaceholder");

                //var Oefeningen = new List<Oefening>();
                //for (int i = 0; i <= 7; i++)
                //{
                //    Oefeningen.Add(new Oefening("OefeningPlaceholder" + i.ToString(), Opgaven[i], Antwoorden[i], feedback, Groepsbewerkingen[i]));
                //}

                //var Acties = new List<Actie>();
                //for (int i = 0; i <= 7; i++)
                //{
                //    Acties.Add(new Actie("ActiePlaceholder" + i.ToString()));
                //}

                //var Box = new Box(Toegangscodes, Acties, Oefeningen);

                //var TBA = new List<Opdracht> {
                //     new Opdracht(1,null,0),
                // };
                #endregion

                _dbContext.Sessies.Add(s);
                _dbContext.SaveChanges();
            }
        }
    }
}
