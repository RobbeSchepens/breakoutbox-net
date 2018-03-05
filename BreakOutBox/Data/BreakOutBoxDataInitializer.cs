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
                    new Toegangscode(0),
                    new Toegangscode(0),
                    new Toegangscode(0),
                    new Toegangscode(0),
                    new Toegangscode(0),
                    new Toegangscode(0),
                    new Toegangscode(0),
                    new Toegangscode(0),
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
                    new Oefening("Oefening1", "", 0, ""),
                    new Oefening("Oefening2", "", 0, ""),
                    new Oefening("Oefening3", "", 0, ""),
                    new Oefening("Oefening4", "", 0, ""),
                    new Oefening("Oefening5", "", 0, ""),
                    new Oefening("Oefening6", "", 0, ""),
                    new Oefening("Oefening7", "", 0, ""),
                    new Oefening("Oefening8", "", 0, "")
                };
               


                Box box = new Box(acties,oefeningen,toegangscodes);


                #endregion






                #region OpdrachtenMaken  

                

                Oefening testest = box.Oefeningen.ToList()[0];
                var opdrachtenGroep1 = new List<Opdracht>{ // lijst met alle opdrachten van groep1 (1,2, 3, 4, 5, 6, 7, 8)             
                    new Opdracht(2,null,box.Oefeningen.ToList()[0],null),
                    new Opdracht(2,null,box.Oefeningen.ToList()[1],null),
                    new Opdracht(3,null,box.Oefeningen.ToList()[2],null),
                    new Opdracht(4,null,box.Oefeningen.ToList()[3],null),
                    new Opdracht(5,null,box.Oefeningen.ToList()[4],null),
                    new Opdracht(6,null,box.Oefeningen.ToList()[5],null),
                    new Opdracht(7,null,box.Oefeningen.ToList()[6],null),
                    new Opdracht(8,null,box.Oefeningen.ToList()[7],null)
                };
                var opdrachtenGroep2 = new List<Opdracht>{ // lijst met alle opdrachten van groep2 (7, 6, 5, 4, 3, 2, 1, 8)
                    new Opdracht(9,null,box.Oefeningen.ToList()[6],null),
                    new Opdracht(10,null,box.Oefeningen.ToList()[5],null),
                    new Opdracht(11,null,box.Oefeningen.ToList()[4],null),
                    new Opdracht(12,null,box.Oefeningen.ToList()[3],null),
                    new Opdracht(13,null,box.Oefeningen.ToList()[2],null),
                    new Opdracht(14,null,box.Oefeningen.ToList()[1],null),
                    new Opdracht(15,null,box.Oefeningen.ToList()[0],null),
                    new Opdracht(16,null,box.Oefeningen.ToList()[7],null)
                };
                var opdrachtenGroep3 = new List<Opdracht>{ // lijst met alle opdrachten van groep3 (3, 5, 7, 1, 2, 4, 6, 8)
                    new Opdracht(17,null,box.Oefeningen.ToList()[2],null),
                    new Opdracht(18,null,box.Oefeningen.ToList()[4],null),
                    new Opdracht(19,null,box.Oefeningen.ToList()[6],null),
                    new Opdracht(20,null,box.Oefeningen.ToList()[0],null),
                    new Opdracht(21,null,box.Oefeningen.ToList()[1],null),
                    new Opdracht(22,null,box.Oefeningen.ToList()[3],null),
                    new Opdracht(23,null,box.Oefeningen.ToList()[5],null),
                    new Opdracht(24,null,box.Oefeningen.ToList()[7],null)
                };
                var opdrachtenGroep4 = new List<Opdracht>{ // lijst met alle opdrachten van groep4 ( 6, 2, 5, 1, 4, 7, 3, 8 )
                    new Opdracht(25,null,box.Oefeningen.ToList()[5],null),
                    new Opdracht(26,null,box.Oefeningen.ToList()[1],null),
                    new Opdracht(27,null,box.Oefeningen.ToList()[4],null),
                    new Opdracht(28,null,box.Oefeningen.ToList()[0],null),
                    new Opdracht(29,null,box.Oefeningen.ToList()[3],null),
                    new Opdracht(30,null,box.Oefeningen.ToList()[6],null),
                    new Opdracht(31,null,box.Oefeningen.ToList()[2],null),
                    new Opdracht(32,null,box.Oefeningen.ToList()[7],null)
                };
                var opdrachtenGroep5 = new List<Opdracht>{ // lijst met alle opdrachten van groep5 (4, 3, 6, 2, 7, 5, 1, 8)
                    new Opdracht(33,null,box.Oefeningen.ToList()[3],null),
                    new Opdracht(34,null,box.Oefeningen.ToList()[2],null),
                    new Opdracht(35,null,box.Oefeningen.ToList()[5],null),
                    new Opdracht(36,null,box.Oefeningen.ToList()[1],null),
                    new Opdracht(37,null,box.Oefeningen.ToList()[6],null),
                    new Opdracht(38,null,box.Oefeningen.ToList()[4],null),
                    new Opdracht(39,null,box.Oefeningen.ToList()[0],null),
                    new Opdracht(40,null,box.Oefeningen.ToList()[7],null)
                };

                #endregion
                #region PadenAanmaken
                var paden = new List<Pad> { // elk pad heeft zijn eigen volgorde van vragen (region: LijstenMetOpdrachtenPerGroep)
                    new Pad(opdrachtenGroep1),
                    new Pad(opdrachtenGroep2),
                    new Pad(opdrachtenGroep3),
                    new Pad(opdrachtenGroep4),
                    new Pad(opdrachtenGroep5)
                };
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





                #region Comments

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
